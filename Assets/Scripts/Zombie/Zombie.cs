using UnityEngine;
using System.Collections.Generic;

public class Zombie : MonoBehaviour, ICharacter, IEnemy {

	private const float MAX_HEALTH = 20;

	private float health;

	public float MaxHealth {
		get {
			return MAX_HEALTH;
		}
	}

	public float Health {
		get {
			return health; 
		}
	}

	public int ScoreValue {
		get {
			return 100;
		}
	}

	private float cooldownAttack = 1;
	private float curTime = 1;

	private float damage = 5;
	private LayerMask playerMask;
	private Vector2 dir = Vector2.down;

	private List<ICharacterEventListener> listeners = new List<ICharacterEventListener>();

	void Start() {
		Alive();
		playerMask = LayerMask.GetMask("Default");
	}


	void Update() {

	}

	private void FixedUpdate() {
		if (curTime >= cooldownAttack) {
			RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, Vector2.one * .5f, 0, dir, .5f, playerMask);
			foreach(RaycastHit2D hit in hits) {
				ICharacter player = hit.transform.GetComponent<ICharacter>();
				if(player != null)
					Attack(player);
			}
		} else {
			curTime += Time.fixedDeltaTime;
		}
	}

	public void Alive() {
		health = MAX_HEALTH;
		foreach(ICharacterEventListener listener in listeners) {
			listener.OnAlive(this);
		}
	}

	public void Death() {
		foreach (ICharacterEventListener listener in listeners) {
			listener.OnDeath(this);
		}
		Destroy(gameObject);
	}

	private void OnHealthChange() {
		foreach (ICharacterEventListener listener in listeners) {
			listener.OnHealthChange(this);
		}
	}

	public void Hit(float damage) {
		health -= damage;
		if(health <= 0) {
			Death();
		}
		OnHealthChange();
	}

	public void FaceDir(Vector2 dir) {
		this.dir = dir;
		transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90);
	}

	public void AddListener(ICharacterEventListener listener) {
		listeners.Add(listener);
	}

	public void RemoveListener(ICharacterEventListener listener) {
		listeners.Remove(listener);
	}

	public void Attack(ICharacter character) {
		character.Hit(damage);
		curTime = 0;
	}
}
