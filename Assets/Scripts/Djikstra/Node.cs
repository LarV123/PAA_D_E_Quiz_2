using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public bool walkable { get; }
	public Vector2 worldPosition { get; }

	public Node(bool _walkable, Vector2 _worldPos) {
		walkable = _walkable;
		worldPosition = _worldPos;
	}
}
