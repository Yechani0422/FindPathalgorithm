using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridNode : IQueueItem<GridNode>
{
	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public GridNode parent;
	int queueIndex;

	public GridNode(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
	{
		walkable = _walkable;
		worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}

	public int fCost
	{
		get
		{
			return gCost + hCost;
		}
	}

	public int QueueIndex
	{
		get
		{
			return queueIndex;
		}
		set
		{
			queueIndex = value;
		}
	}

	public int CompareTo(GridNode nodeToCompare)
	{
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if (compare == 0)
		{
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}
