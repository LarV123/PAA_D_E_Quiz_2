using UnityEngine;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour, IScore {

	private int score;

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

	void Start() {

	}
	
	void Update() {

	}

	public void AddScore(int number) {
		ScoreValue += number;
	}

	public void SubtractScore(int number) {
		ScoreValue -= number;
	}

	public void AddListener(IScoreEventListener listener) {
		throw new System.NotImplementedException();
	}

	public void RemoveListener(IScoreEventListener listener) {
		throw new System.NotImplementedException();
	}
}
