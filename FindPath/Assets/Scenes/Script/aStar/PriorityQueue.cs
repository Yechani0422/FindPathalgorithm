using UnityEngine;
using System.Collections;
using System;

public class PriorityQueue<T> where T : IQueueItem<T>
{

	T[] items;
	int currentItemCount;

	public PriorityQueue(int maxHeapSize)
	{
		items = new T[maxHeapSize];
	}

	public void Add(T item)
	{
		item.QueueIndex = currentItemCount;
		items[currentItemCount] = item;
		SortUp(item);
		currentItemCount++;
	}

	public T RemoveFirst()
	{
		T firstItem = items[0];
		currentItemCount--;
		items[0] = items[currentItemCount];
		items[0].QueueIndex = 0;
		SortDown(items[0]);
		return firstItem;
	}

	public void UpdateItem(T item)
	{
		SortUp(item);
	}

	public int Count
	{
		get
		{
			return currentItemCount;
		}
	}

	public bool Contains(T item)
	{
		return Equals(items[item.QueueIndex], item);
	}

	void SortDown(T item)
	{
		while (true)
		{
			int childIndexLeft = item.QueueIndex * 2 + 1;
			int childIndexRight = item.QueueIndex * 2 + 2;
			int swapIndex = 0;

			if (childIndexLeft < currentItemCount)
			{
				swapIndex = childIndexLeft;

				if (childIndexRight < currentItemCount)
				{
					if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
					{
						swapIndex = childIndexRight;
					}
				}

				if (item.CompareTo(items[swapIndex]) < 0)
				{
					Swap(item, items[swapIndex]);
				}
				else
				{
					return;
				}

			}
			else
			{
				return;
			}

		}
	}

	void SortUp(T item)
	{
		int parentIndex = (item.QueueIndex - 1) / 2;

		while (true)
		{
			T parentItem = items[parentIndex];
			if (item.CompareTo(parentItem) > 0)
			{
				Swap(item, parentItem);
			}
			else
			{
				break;
			}

			parentIndex = (item.QueueIndex - 1) / 2;
		}
	}

	void Swap(T itemA, T itemB)
	{
		items[itemA.QueueIndex] = itemB;
		items[itemB.QueueIndex] = itemA;
		int itemAIndex = itemA.QueueIndex;
		itemA.QueueIndex = itemB.QueueIndex;
		itemB.QueueIndex = itemAIndex;
	}
}

public interface IQueueItem<T> : IComparable<T>
{
	int QueueIndex
	{
		get;
		set;
	}
}
