using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour, ICharacter, IPickuper {

	private const float MAX_HEALTH = 100;

	private float speed = 5;
	private float health;

	private Rigidbody2D rb2d;

	private Gun gun;

	public float Health {
		get {
			return health;
		}
	}

	private List<ICharacterEventListener> listeners = new List<ICharacterEventListener>();

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start() {
		gun = GetComponentInChildren<Gun>();
		Alive();
	}
	
	void Update() {

	}

	public void PointTo(Vector2 dir) {
		if(gun != null) {
			gun.PointTo(dir);
		}
	}

	public void Shoot() {
		gun.Shoot();
	}

	public void Move(Vector2 dir) {
		rb2d.velocity = dir * speed;
	}

	public void Heal(float healPoint) {
		health += healPoint;
		if(health > MAX_HEALTH) {
			health = MAX_HEALTH;
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
	}

	public void Pickup(IPickupable ipuckable) {

	}

	public void Hurt(float damage) {
		health -= damage;
		if(health <= 0) {
			Death();
		}
	}

	public void AddListener(ICharacterEventListener listener) {
		listeners.Add(listener);
	}

	public void RemoveListener(ICharacterEventListener listener) {
		listeners.Remove(listener);
	}
}
