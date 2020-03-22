using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField]
	private Vector2 worldSize;
	[SerializeField]
	private float gridSizeX;
	[SerializeField]
	private float gridSizeY;
	public int gridNumberX { get; private set; }
	public int gridNumberY { get; private set; }

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
	}
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y,1));
	}
}
