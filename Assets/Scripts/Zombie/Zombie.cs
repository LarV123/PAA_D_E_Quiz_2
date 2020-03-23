using UnityEngine;
using System.Collections.Generic;

public class Zombie : MonoBehaviour, ICharacter, IEnemy {

	private const float MAX_HEALTH = 20;

	private float health;

	public float Health {
		get {
			return health; 
		}
	}

	private float damage = 5;

	private List<ICharacterEventListener> listeners = new List<ICharacterEventListener>();

	void Start() {

	}


	void Update() {

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

	public void Attack(ICharacter character) {
		character.Hurt(damage);
	}
}
