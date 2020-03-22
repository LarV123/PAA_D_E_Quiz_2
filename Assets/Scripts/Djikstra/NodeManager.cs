using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
	[SerializeField]
	private LayerMask unwalkableMask;
	[SerializeField]
	private GridManager grid;
	public Node[,] nodes { get; private set; }

	void Start() {
		CreateNodes();
	}

	private void CreateNodes() {
		Vector2[,] gridPos = grid.gridPos;
		nodes = new Node[gridPos.GetLength(0), gridPos.GetLength(1)];

		for (int i = 0; i < gridPos.GetLength(0); i++) {
			for(int j = 0; j < gridPos.GetLength(1); j++) {
				RaycastHit2D cast = Physics2D.BoxCast(gridPos[i, j], new Vector2(grid.GetGridSizeX(), grid.GetGridSizeY()),0f,Vector2.zero,0f,unwalkableMask);
				bool walkable = !(cast);
				nodes[i, j] = new Node(walkable, gridPos[i, j]);
			}
		}
	}

	void OnDrawGizmos() {
		if(nodes != null) {
			foreach(Node n in nodes) {
				Gizmos.color = (n.walkable) ? Color.green : Color.red;
				Gizmos.DrawCube(n.worldPosition, new Vector3(grid.GetGridSizeX()-0.3f, grid.GetGridSizeY() - 0.3f, 1f));
			}
		}
	}
}
