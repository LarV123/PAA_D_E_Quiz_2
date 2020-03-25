using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI score, highScore;

	public void SetScore(int score) {
		this.score.SetText("Score : " + score);
	}

	public void SetHighscore(int highscore) {
		this.highScore.SetText("Score : " + highscore);
	}

	public void Retry() {
		SceneManager.LoadScene(1);
	}

	public void Back() {
		SceneManager.LoadScene(0);
	}

}
