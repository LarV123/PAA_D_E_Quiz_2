using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int curWave;
	private int maxEnemies = 10;

	[SerializeField] private GameObject enemyPrefab;

	void Start() {

	}
	
	void Update() {

	}

	private int WaveToNumOfEnemy() {
		int numOfEnemies = curWave * 2;
		if (numOfEnemies < maxEnemies)
			return numOfEnemies;
		else
			return maxEnemies;
	}
}
