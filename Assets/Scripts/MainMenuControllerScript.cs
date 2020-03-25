using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuControllerScript : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI hs;

	private void Awake() {
		hs.text = ""+ SaveSystem.Instance.FileSave.highScore;
	}

	public void PlayScene() {
		SceneManager.LoadScene(1);
	}

	public void ExitGame() {
		Application.Quit();
	}
	
}
