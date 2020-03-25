using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityNode : Node, IComparable<PriorityNode> {

	public int hcost { private get; set; }
	public int gcost { get; set; }

	public PriorityNode(Node n) : base(n.walkable,n.worldPosition) {
		hcost = 0;
		gcost = 0;
	}
	public int getFCost() {
		return hcost + gcost;
	}

	public int CompareTo(PriorityNode other) {
		return Mathf.RoundToInt((this.getFCost() - other.getFCost()) * 100);
	}
}
