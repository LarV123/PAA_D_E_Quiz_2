using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField]
	private Transform gridArea;
	[SerializeField]
	private Vector2 worldSize;
	[SerializeField]
	private float gridSizeX;
	[SerializeField]
	private float gridSizeY;

	public int gridNumberX { get; private set; }
	public int gridNumberY { get; private set; }

	public Vector2[,] gridPos { get; private set; }

	public Vector2 GetWorldSize() {
		return worldSize;
	}

	public float GetGridSizeX() {
		return gridSizeX;
	}

	public float GetGridSizeY() {
		return gridSizeY;
	}

	void Start() {
		gridNumberX = Mathf.RoundToInt(worldSize.x / gridSizeX);
		gridNumberY = Mathf.RoundToInt(worldSize.y / gridSizeY);


		gridPos = new Vector2[gridNumberX, gridNumberY];
		Vector2 WorldBottomLeft = Vector2.one *	(gridArea.position) - Vector2.right * (GetWorldSize().x/2f - GetGridSizeX()/2f) - Vector2.up * (GetWorldSize().y/2f - GetGridSizeY()/2f);
		for(int i = 0; i < gridNumberX; i++) {
			for(int j = 0; j < gridNumberY; j++) {
				Vector2 worldPoint = WorldBottomLeft + Vector2.right * (i * GetGridSizeX()) + Vector2.up * (j * GetGridSizeY());
				gridPos[i, j] = worldPoint;
				//Debug.Log(gridPos[i, j]);
			}
		}
	}
		
	public Tuple<int,int> getGridIndexFromWorldPos(Vector2 worldPosition) {
		float percentX = (worldPosition.x + worldSize.x / 2f) / worldSize.x;
		float percentY = (worldPosition.y + worldSize.y / 2f) / worldSize.y;

		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.FloorToInt((gridNumberX) * percentX);
		int y = Mathf.FloorToInt((gridNumberY) * percentY);

		Debug.Log(percentX + " " + percentY);
		return new Tuple<int, int>(x, y);
	}
	//void OnDrawGizmos() {
	//	Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y,1));

	//	if (gridPos != null) {
	//		foreach (Vector2 v in gridPos) {
	//			Debug.Log(v);
	//			Gizmos.color = Color.gray;
	//			Gizmos.DrawCube(Vector3.one * v, Vector3.one * new Vector2(gridSizeX - 0.1f, gridSizeY - 0.1f));
	//		}
	//	}
	//}
}
