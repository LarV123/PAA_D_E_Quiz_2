using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable<Node>
{
	public bool walkable { get; }
	public Vector2 worldPosition { get; }
	public int hcost { private get; set; }
	public int gcost { get; set; }
	
	public int getFCost() {
		return hcost + gcost;
	}

	public Node(bool _walkable, Vector2 _worldPos) {
		walkable = _walkable;
		worldPosition = _worldPos;
		hcost = 0;
		gcost = 0;
	}

	public int CompareTo(Node other) {
		return Mathf.RoundToInt((this.getFCost() - other.getFCost())*100);
	}
}
