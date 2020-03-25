using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public bool walkable { get; protected set; }
	public Vector2 worldPosition { get; protected set; }
	

	public Node(bool _walkable, Vector2 _worldPos) {
		walkable = _walkable;
		worldPosition = _worldPos;
	}

	
}
