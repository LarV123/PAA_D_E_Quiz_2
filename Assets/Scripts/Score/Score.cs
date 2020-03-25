using UnityEngine;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour, IScore {

	private int score = 0;

	private TextMeshProUGUI text;

	public int ScoreValue {
		get {
			return score;
		}
		set {
			score = value;
			text.text = string.Format("Score : {0}", score);
		}
	}

	private void Awake() {
		text = GetComponent<TextMeshProUGUI>();
	}

	public void AddScore(int number) {
		ScoreValue += number;
	}

	public void SubtractScore(int number) {
		ScoreValue -= number;
	}
}
