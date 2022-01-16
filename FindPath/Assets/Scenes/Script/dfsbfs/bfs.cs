using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bfs : MonoBehaviour
{
    int number = 7;
    int INF = 1000000000;

    bool[] visited;
    List<Edge> graph;
    List<int>[] edgeList;

    bool check;
    // Start is called before the first frame update
    void Start()
    {
        visited = new bool[number];
        graph = this.gameObject.GetComponent<dfsbfsGraph>()._edgeList;
        edgeList = new List<int>[number];
        for (int i = 0; i < number; i++)
        {
            edgeList[i] = new List<int>();
        }
        addEdge();

        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (check != true)
        {
            travel();
        }
    }

    void addEdge()
    {
        for (int i = 0; i < graph.Count; i++)
        {
            edgeList[graph[i].LeftNode.getNode()].Add(graph[i].RightNode.getNode());
            //edgeList[graph[i].RightNode.getNode()].Add(graph[i].LeftNode.getNode());
        }
    }

    void travel()
    {
        for (int i = 0; i < number; i++)
        {
            visited[i] = false;
        }
        check = true;
        StartCoroutine(Bfs(1));
    }

    IEnumerator Bfs(int start)
    {
        Queue<int> q = new Queue<int>();

        visited[start] = true;
        q.Enqueue(start);

        while (q.Count != 0)
        {
            int tmp = q.Dequeue();

            yield return new WaitForSeconds(1);
            Debug.Log(tmp);
            GameObject pathNode;
            pathNode = GameObject.Find(tmp.ToString());
            pathNode.GetComponent<MeshRenderer>().material.color = Color.red;

            for(int next=0;next<edgeList[tmp].Count;next++)
            {
                if (visited[edgeList[tmp][next]] != true)
                {
                    visited[edgeList[tmp][next]] = true;
                    q.Enqueue(edgeList[tmp][next]);
                }
            }
        }
    }
}
