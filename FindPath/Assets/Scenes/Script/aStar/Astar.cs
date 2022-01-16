using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Astar : MonoBehaviour
{

	public Transform seeker, target;
	GridGraph grid;
	public Stack<GridNode> UnitPath;

	void Awake()
	{
		grid = GetComponent<GridGraph>();
		UnitPath = new Stack<GridNode>();
	}

	void Update()
	{
		AstarFindPath(seeker.position, target.position);
	}

	void AstarFindPath(Vector3 startPos, Vector3 targetPos)
	{
		GridNode startNode = grid.NodeFromWorldPoint(startPos);
		GridNode targetNode = grid.NodeFromWorldPoint(targetPos);

		PriorityQueue<GridNode> openSet = new PriorityQueue<GridNode>(grid.MaxSize);
		HashSet<GridNode> closedSet = new HashSet<GridNode>();
		openSet.Add(startNode);

		
		startNode.gCost = 0;		
		
		while (openSet.Count > 0)
		{
			GridNode current = openSet.RemoveFirst();
			closedSet.Add(current);

			if (current == targetNode)
			{
				BacktrackPath(startNode, targetNode);
				return; 
			}

			foreach (GridNode neighbour in grid.GetNeighbours(current))
			{
				if (!neighbour.walkable || closedSet.Contains(neighbour))
				{
					continue;
				}

				int nextDistance = current.gCost + Heuristic(current, neighbour);
				if (nextDistance < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = nextDistance;
					neighbour.hCost = Heuristic(neighbour, targetNode);
					neighbour.parent = current;

					if (!openSet.Contains(neighbour))
                    {
						openSet.Add(neighbour);
					}						
				}
			}
		}
	}

	void BacktrackPath(GridNode startNode, GridNode endNode)
	{
		List<GridNode> path = new List<GridNode>();
		GridNode currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			UnitPath.Push(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		grid.path = path;

	}

	int Heuristic(GridNode nodeA, GridNode nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
        {
			return 14 * dstY + 10 * (dstX - dstY);
		}			
		return 14 * dstX + 10 * (dstY - dstX);
	}
}
