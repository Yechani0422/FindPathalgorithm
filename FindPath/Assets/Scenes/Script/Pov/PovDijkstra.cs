using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovDijkstra : MonoBehaviour
{
    [SerializeField]
    public int start;
    [SerializeField]
    public int end;

    int number = 20;
    int INF = 1000000000;

    int[] d = new int[21];
    public bool check;
    public Priority_Queue<KeyValuePair<int, int>> pq;// 힙구조 유지

    List<Edge> graph;
    int[] Path;

    public Stack<int> S;
    // Start is called before the first frame update
    void Start()
    {
        S = new Stack<int>();
        Path = new int[21];
        pq = new Priority_Queue<KeyValuePair<int, int>>();
        graph = this.gameObject.GetComponent<PovGraph>()._edgeList;
        for (int i = 1; i <= number; i++)
        {
            d[i] = INF;
        }
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (check != true)
        {
            Dijkstra(start);

            Debug.Log(start + "에서" + end + "까지의 비용:" + d[end]);

            BacktrackPath(Path, end);
        }
    }

    public void Reset()
    {
        S = new Stack<int>();
        Path = new int[21];
        pq = new Priority_Queue<KeyValuePair<int, int>>();
        graph = this.gameObject.GetComponent<PovGraph>()._edgeList;
        for (int i = 1; i <= number; i++)
        {
            d[i] = INF;
        }
        check = true;
    }

    void Dijkstra(int start)
    {
        d[start] = 0; // 탐색 시작하는 노드의 최소비용은 0

        pq.push(new KeyValuePair<int, int>(start, Heuristic(start)));
        //pq.push(new KeyValuePair<int, int>(start, 0));

        // 가까운 순서대로 처리 -> 큐 사용
        while (!pq.empty())
        { // 우선순위 큐가 비어있지 않다면 
            int current = pq.top().Key; // 큐의 가장 위에는 가장 적은 비용을 가진 node의 정보가 들어있다.

            // 짧은 것이 먼저 오도록 음수화
            int distance = -pq.top().Value;

            pq.pop();

            // 최단 거리가 아닌 경우 스킵
            if (d[current] < distance) continue;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].LeftNode.getNode() == current)
                {
                    // 선택된 노드의 인접노드를 담아줌 
                    int next = graph[i].RightNode.getNode();
                    // 선택된 노드를 거쳐서 인접노드로 가는 비용 계산
                    int nextDistance = distance + graph[i].Weight+Heuristic(current);

                    // 기존의 비용과 비교
                    if (nextDistance < d[next])
                    {
                        d[next] = nextDistance;
                        //pq.push(new KeyValuePair<int, int>(next, -nextDistance));
                        pq.push(new KeyValuePair<int, int>(next, -nextDistance + Heuristic(next)));
                        Path[next] = current;
                    }
                }

            }

        }
        check = true;
    }

    public int Heuristic(int now)
    {
        float nowX=0;
        float nowY=0;
        float endX=0;
        float endY=0;

        GameObject nowNode;
        GameObject endNode;

        nowNode = GameObject.Find(now.ToString());
        endNode = GameObject.Find(end.ToString());

        nowX = nowNode.transform.position.x;
        nowY = nowNode.transform.position.z;

        endX = endNode.transform.position.x;
        endY = endNode.transform.position.z;

        return (int)Mathf.Sqrt(Mathf.Pow(nowX - endX, 2) + Mathf.Pow(nowY - endY, 2));
        //return 0;
    }

    void BacktrackPath(int[] Path, int end)
    {
        S.Push(end);
        for (int i = Path[end]; i != 0;)
        {
            S.Push(i);
            i = Path[i];
        }

        //while (S.Count != 0)
        //{
        //    Debug.Log(S.Peek());

        //    GameObject pathNode;
        //    pathNode = GameObject.Find(S.Peek().ToString());
        //    pathNode.GetComponent<MeshRenderer>().material.color = Color.red;

        //    S.Pop();
        //}
    }
}
