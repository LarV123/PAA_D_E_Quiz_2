using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IPickuper {

	private const float MAX_HEALTH = 100;

	private float speed = 5;
	private float health = 100;

	private Rigidbody2D rb2d;

	private Gun gun;

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start() {
		gun = GetComponentInChildren<Gun>();
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

	public void Pickup(IPickupable ipuckable) {

	}
}
