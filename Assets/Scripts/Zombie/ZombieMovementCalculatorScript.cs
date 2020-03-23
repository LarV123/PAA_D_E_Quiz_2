using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementCalculatorScript : MonoBehaviour
{
	// Start is called before the first frame update
	private NodeManager nodeManager;
	private ZombieControllerScript zombieController;

	void Start() {
		nodeManager = GameObject.Find("NodeManager").GetComponent<NodeManager>();
		zombieController = GetComponent<ZombieControllerScript>();
		InvokeRepeating("CalculatePath", 2f, 10f);
	}

	void CalculatePath() {
		Debug.Log("Calculating path");
	}
}
