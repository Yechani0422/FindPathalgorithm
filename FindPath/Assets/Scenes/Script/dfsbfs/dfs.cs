using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class dfs : MonoBehaviour
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
        for(int i=0;i<number;i++)
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
        for(int i=0;i<graph.Count;i++)
        {
            edgeList[graph[i].LeftNode.getNode()].Add(graph[i].RightNode.getNode());
            edgeList[graph[i].RightNode.getNode()].Add(graph[i].LeftNode.getNode());
        }
    }

    void travel()
    {
        for (int i = 0; i < number; i++)
        {
            visited[i] = false;
        }
        check = true;
        StartCoroutine(Dfs(1));
    }

    IEnumerator Dfs(int i)
    {
        //stack알고리즘
        Stack<int> stack = new Stack<int>();
        visited[i] = true;

        stack.Push(i);

        while (stack.Count != 0)
        {
            i = stack.Pop();

            yield return new WaitForSeconds(1);
            Debug.Log(i);
            GameObject pathnode;
            pathnode = GameObject.Find(i.ToString());
            pathnode.GetComponent<MeshRenderer>().material.color = Color.red;

            foreach (int v in edgeList[i])
            {
                if (!visited[v])
                {
                    visited[v] = true;
                    stack.Push(v);
                }
            }
        }


        ////재귀함수 알고리즘
        //visited[i] = true;

        //Debug.Log(i);
        //GameObject pathNode;
        //pathNode = GameObject.Find(i.ToString());
        //pathNode.GetComponent<MeshRenderer>().material.color = Color.red;

        //foreach (int v in edgeList[i])
        //{
        //    if (visited[v] != true)
        //    {
        //        StartCoroutine(Dfs(v));
        //        yield return new WaitForSeconds(1);
        //    }
        //}
    }
}
