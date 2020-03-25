using UnityEngine;
using System.Collections;

[System.Serializable]
public class SaveFile {

	public int highScore;

	public SaveFile(int highScore) {
		this.highScore = highScore;
	}

	public SaveFile() {
		highScore = 0;
	}

}
