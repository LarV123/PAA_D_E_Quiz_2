using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementCalculatorScript : MonoBehaviour
{
	// Start is called before the first frame update
	private List<Node> nodes;
	[SerializeField]
	private Player player;
	private static NodeManager nodeManager;
	private ZombieControllerScript zombieController;

	void Start() {
		nodeManager = GameObject.Find("NodeManager").GetComponent<NodeManager>();
		zombieController = GetComponent<ZombieControllerScript>();
		//player = GameObject.Find("Player").GetComponent<Player>();
		InvokeRepeating("CalculatePath", 2f, 10f);
	}

	void CalculatePath() {
		Debug.Log("Calculating path");
		nodes = AStarPathNode();
	}

	//diagonal sama vertical nilainya sama jadinya dua duanya kehitung path bug
	private List<Node> AStarPathNode() {
		Node thisNode = nodeManager.getNodeFromWorldPosition(transform.position);
		Node playerNode = nodeManager.getNodeFromWorldPosition(player.transform.position);
		nodeManager.initHCost(thisNode, playerNode);

		List<Node> pathList = new List<Node>();
		Dictionary<Node, int> curFCost = new Dictionary<Node, int>();
		PriorityQueue<Node> queue = new PriorityQueue<Node>();

		foreach(Node n in nodeManager.getNeighbor(thisNode)) {
			if (!n.walkable) continue;
			n.gcost++;
			curFCost[n] = n.getFCost();
			queue.Enqueue(n);
		}
		while(queue.Count() > 0) {
			Node current = queue.Dequeue();
			if (current == playerNode) break;
			pathList.Add(current);

			foreach (Node n in nodeManager.getNeighbor(current)) {
				if (!n.walkable) continue;
				n.gcost = current.gcost + 1;
				if (curFCost.ContainsKey(n)) {
					if (curFCost[n] > n.getFCost()) {
						queue.Remove(n);
					}
				}
				curFCost[n] = n.getFCost();
				queue.Enqueue(n);
			}
		}

		return pathList;
	}

	void OnDrawGizmos() {
		foreach(Node n in nodes) {
			Gizmos.color = Color.blue;
			Gizmos.DrawCube(n.worldPosition, new Vector3(3f - 0.3f, 3f - 0.3f, 1f));
		}
	}
}
