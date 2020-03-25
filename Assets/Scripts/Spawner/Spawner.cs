using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ISpawner {
	
	private Transform[] spawnPoints;

	private void Awake() {
		spawnPoints = new Transform[transform.childCount];
		int i = 0;
		foreach(Transform child in transform) {
			spawnPoints[i++] = child;
		}
	}

	private Transform RandomSpawnPoint() {
		int index = Random.Range(0, spawnPoints.Length);
		return spawnPoints[index];
	}

	public void Spawn(GameObject gameObject) {
		Vector2 pos = RandomSpawnPoint().position;
		GameObject spawnedObject = Instantiate(gameObject, pos, Quaternion.identity);
	}

}
