using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControllerScript : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D rb;
	private ZombieScript zombie;

	void Start() {
		zombie = GetComponent<ZombieScript>();
		rb = zombie.GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 dir) {
		rb.velocity = dir * zombie.speed;
	}

}
