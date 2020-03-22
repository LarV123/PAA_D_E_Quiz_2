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
	Node[,] nodes;

	void Start() {
		CreateGrid();
	}

	private void CreateGrid() {
		nodes = new Node[grid.gridNumberX, grid.gridNumberY];

	}
}
