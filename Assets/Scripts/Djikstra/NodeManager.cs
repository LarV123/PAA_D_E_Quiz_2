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

	public Tuple<int,int> getIndexFromNode(Node n) {
		int w = nodes.GetLength(0); // width
		int h = nodes.GetLength(1); // height

		for (int x = 0; x < w; ++x) {
			for (int y = 0; y < h; ++y) {
				if (nodes[x, y].Equals(n))
					return Tuple.Create(x, y);
			}
		}

		return Tuple.Create(-1, -1);
	}

	private float manhattanHeuristic(Node newNode, Node end) {
		Tuple<int, int> _newnode = getIndexFromNode(newNode);
		Tuple<int, int> _end = getIndexFromNode(newNode);
		return (Math.Abs(_newnode.Item1 - _end.Item1) + Math.Abs(_newnode.Item2 - _end.Item2));
	}

	public void initHCost(Node start, Node end) {
		int w = nodes.GetLength(0); // width
		int h = nodes.GetLength(1); // height
		Tuple<int, int> _end = getIndexFromNode(end);

		for (int x = 0; x < w; ++x) {
			for (int y = 0; y < h; ++y) {
				nodes[x, y].hcost = Mathf.Abs(x - _end.Item1) + Mathf.Abs(y - _end.Item2);
			}
		}
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

	public List<Node> getNeighbor(Node n) {
		List<Node> returnArray = new List<Node>();
		int[] dr = { 1, 1, 0, -1, -1, -1, 0, 1 };
		int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };

		Tuple<int, int> nodeIndex = getIndexFromNode(n);
		for(int i = 0; i < 8; i++) {
			int xIndex = nodeIndex.Item1 + dr[i];
			int yIndex = nodeIndex.Item2 + dc[i];

			if (xIndex < 0 || xIndex > grid.gridNumberX) continue;
			if (yIndex < 0 || yIndex > grid.gridNumberY) continue;

			returnArray.Add(nodes[xIndex, yIndex]);
		}

		return returnArray;
	}
}
