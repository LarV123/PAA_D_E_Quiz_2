using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class WaveManager : ICharacterEventListener{

	private int curWave = 0;
	private int maxEnemies = 5;
	private int curEnemyCount = 0;
	private ISpawner spawner;
	private GameObject enemyPrefab;
	private TextMeshProUGUI text;
	private List<ICharacterEventListener> characterListeners = new List<ICharacterEventListener>();

	public WaveManager(ISpawner spawner, GameObject enemyPrefab, TextMeshProUGUI text) {
		this.spawner = spawner;
		this.enemyPrefab = enemyPrefab;
		this.text = text;
	}

	public void StartNewWave() {
		curWave++;
		SetWaveText();
		for(int i = 0; i < WaveToNumOfEnemy(); i++) {
			ICharacter character = spawner.Spawn(enemyPrefab).GetComponent<ICharacter>();
			character.AddListener(this);
			foreach(ICharacterEventListener listener in characterListeners) {
				character.AddListener(listener);
			}
		}
	}

	public void OnAlive(ICharacter character) {
		if(character is Zombie) {
			curEnemyCount++;
		}
	}

	public void OnDeath(ICharacter character) {
		if(character is Zombie) {
			curEnemyCount--;
		}
		if(curEnemyCount == 0) {
			StartNewWave();
		}
	}

	public void OnHealthChange(ICharacter character) {

	}

	private int WaveToNumOfEnemy() {
		int numOfEnemies = curWave * 2;
		if (numOfEnemies < maxEnemies)
			return numOfEnemies;
		else
			return maxEnemies;
	}

	private void SetWaveText() {
		text.SetText(string.Format("Wave : {0}", curWave));
	}

	public void AddCharacterListener(ICharacterEventListener listener) {
		characterListeners.Add(listener);
	}

	public void RemoveCharacterListener(ICharacterEventListener listener) {
		characterListeners.Remove(listener);
	}
}
