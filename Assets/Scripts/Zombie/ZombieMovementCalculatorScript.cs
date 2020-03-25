using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementCalculatorScript : MonoBehaviour
{
	// Start is called before the first frame update
	private Queue<Node> qnodes;
	private List<Node> lnodes;
	private Vector2 nextNode;
	[SerializeField]
	private Player player;
	private static NodeManager nodeManager;
	private ZombieControllerScript zombieController;

	void Start() {
		nodeManager = GameObject.Find("NodeManager").GetComponent<NodeManager>();
		zombieController = GetComponent<ZombieControllerScript>();
		qnodes = new Queue<Node>();
		InvokeRepeating("CalculatePath", 0f, 10f);
	}

	private void Update() {
		Vector2 dir = (nextNode - Vector2.one * transform.position).normalized;
		zombieController.Look(dir);
		zombieController.Move(dir);
		float distance = Vector2.Distance(transform.position, nextNode);
		//Debug.Log("Transform : " + Vector2.one * transform.position + " Node position : " + nextNode + " Direction : " + dir);
		if(distance < 0.5f) {
			nextNodeInQueue();
		}
	}

	void nextNodeInQueue() {
		if(qnodes.Count > 0)
			nextNode = qnodes.Dequeue().worldPosition;
		else {
			nextNode = player.transform.position;
		}
	}

	void CalculatePath() {
		Debug.Log("Calculating path");
		lnodes = AStarPathNode();
		qnodes.Clear();
		foreach(Node n in lnodes) {
			qnodes.Enqueue(n);
		}
		nextNodeInQueue();
	}

	//diagonal sama vertical nilainya sama jadinya dua duanya kehitung path bug
	private List<Node> AStarPathNode() {

		PriorityNode[,] nodes = initPriorityNode();
		Node thisNode = nodeManager.getNodeFromWorldPosition(nodes, Vector2.one * transform.position);
		Node playerNode = nodeManager.getNodeFromWorldPosition(nodes, Vector2.one * player.transform.position);
		initHCost(nodes, thisNode, playerNode);


		List<Node> pathList = new List<Node>();
		Dictionary<PriorityNode, int> curFCost = new Dictionary<PriorityNode, int>();
		Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
		PriorityQueue<PriorityNode> queue = new PriorityQueue<PriorityNode>();


		PriorityNode startpn = (PriorityNode)thisNode;
		curFCost[startpn] = startpn.getFCost();
		cameFrom[startpn] = thisNode;
		queue.Enqueue(startpn);


		while(queue.Count() > 0) {
			PriorityNode current = queue.Dequeue();
			if (current == playerNode) break;

			foreach (Node n in nodeManager.getNeighbor(nodes,current)) {
				if (!n.walkable) continue;
				PriorityNode pn = (PriorityNode)n;
				pn.gcost = current.gcost + 1;
				if (!curFCost.ContainsKey(pn) || curFCost[pn] > pn.getFCost()) {
					cameFrom[pn] = current;
					curFCost[pn] = pn.getFCost();
					queue.Enqueue(pn);
				}
			}
		}

		Node cur = playerNode;
		while(cur != thisNode) {
			pathList.Add(cur);
			cur = cameFrom[cur];
		}
		pathList.Remove(playerNode);
		pathList.Remove(thisNode);
		pathList.Reverse();

		return pathList;
	}


	private PriorityNode[,] initPriorityNode() {
		if(nodeManager.nodes == null)
			Debug.Log(transform.name);
		int w = nodeManager.nodes.GetLength(0); // width
		int h = nodeManager.nodes.GetLength(1); // height

		PriorityNode[,] pnodes = new PriorityNode[w, h];

		for (int x = 0; x < w; ++x) {
			for (int y = 0; y < h; ++y) {
				pnodes[x, y] = new PriorityNode(nodeManager.nodes[x, y]);
			}
		}
		return pnodes;
	}


	private void initHCost(PriorityNode[,] nodes,Node start, Node end) {
		int w = nodes.GetLength(0); // width
		int h = nodes.GetLength(1); // height
		Tuple<int, int> _end = nodeManager.getIndexFromNode(nodes,end);

		for (int x = 0; x < w; ++x) {
			for (int y = 0; y < h; ++y) {
				nodes[x, y].hcost = Mathf.Abs(x - _end.Item1) + Mathf.Abs(y - _end.Item2);
			}
		}
	}


	
}
