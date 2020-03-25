﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControllerScript : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D rb;
	private ZombieScript zombie;
	private float rotationSpeed = 0.2f;

	void Start() {
		zombie = GetComponent<ZombieScript>();
		rb = zombie.GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 dir) {
		rb.velocity = dir * zombie.speed;
	}

	public void Look(Vector2 dir) {
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}