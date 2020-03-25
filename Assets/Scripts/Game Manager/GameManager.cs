using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour, ICharacterEventListener {

	private IScore score;
	[SerializeField] private GameObject scoreGameObject;
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private TextMeshProUGUI waveText;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject GameOverObject;
	WaveManager waveManager;
	ISpawner spawner;

	void Start() {
		spawner = GetComponent<ISpawner>();
		waveManager = new WaveManager(spawner, enemyPrefab, waveText);
		waveManager.AddCharacterListener(this);
		waveManager.StartNewWave();
		score = scoreGameObject.GetComponent<IScore>();
		player.GetComponent<ICharacter>().AddListener(this);
	}

	void Update() {

	}

	public void OnAlive(ICharacter character) {

	}

	public void OnDeath(ICharacter character) {
		if (character is IEnemy) {
			score.AddScore(((IEnemy)character).ScoreValue);
		} else {
			GameOver();
		}
	}

	private void GameOver() {
		GameOver go = GameOverObject.GetComponent<GameOver>();
		go.SetScore(score.ScoreValue);
		if(score.ScoreValue >= SaveSystem.Instance.FileSave.highScore) {
			SaveSystem.Instance.FileSave.highScore = score.ScoreValue;
			SaveSystem.Instance.SaveFile();
		}
		go.SetHighscore(SaveSystem.Instance.FileSave.highScore);
		GameOverObject.SetActive(true);
	}

	public void OnHealthChange(ICharacter character) {

	}

}
