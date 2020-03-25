using UnityEngine;
using System.Collections;

public class GameInputHandler : MonoBehaviour {

	[SerializeField] private Player player;
	private Camera mainCamera;

	private void Awake() {
		mainCamera = Camera.main;
	}

	void Start() {

	}
	
	void Update() {
		float horizontalAxis = Input.GetAxisRaw("Horizontal");
		float verticalAxis = Input.GetAxisRaw("Vertical");
		player.Move(new Vector2(horizontalAxis, verticalAxis));

		Vector2 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		player.FaceDir((mousePosInWorldSpace - (Vector2)player.transform.position).normalized);

		if (Input.GetButton("Fire1")) {
			player.Shoot();
		}
	}


}
