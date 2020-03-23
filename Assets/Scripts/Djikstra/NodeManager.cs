using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
	[SerializeField]
	private Transform Zombie;
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

	public Node getNodeFromWorldPosition(Vector2 worldPosition) {
		Tuple<int, int> index = grid.getGridIndexFromWorldPos(worldPosition);

		return nodes[index.Item1, index.Item2];
	}
	void OnDrawGizmos() {
		if(nodes != null) {
			Node zombieNode = getNodeFromWorldPosition(Zombie.position);
			foreach(Node n in nodes) {
				Gizmos.color = (n.walkable) ? Color.green : Color.red;
				if (n == zombieNode) Gizmos.color = Color.cyan;
				Gizmos.DrawCube(n.worldPosition, new Vector3(grid.GetGridSizeX()-0.3f, grid.GetGridSizeY() - 0.3f, 1f));
			}
		}
	}
}
