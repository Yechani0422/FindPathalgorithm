using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Priority_Queue<T>
//{
//    List<KeyValuePair<int,int>> nowList;

//    public Priority_Queue()
//    {
//        nowList = new List<KeyValuePair<int, int>>();
//    }

//    public void push(KeyValuePair<int, int> data)
//    {
//        int count = nowList.Count;
//        int index = -1;
//        if (count < 1)
//        {
//            nowList.Add(data);
//            return;
//        }

//        for (int i = count; --i > -1;)
//        {
//            if (nowList[i].Value< data.Value)
//            {
//                index = i + 1;
//                break;
//            }
//        }
//        if(index.Equals(-1))
//        {
//            index = 0;
//        }
//        nowList.Insert(index, data);
//    }

//    public KeyValuePair<int, int> pop()
//    {
//        KeyValuePair<int, int> g = nowList[0];
//        nowList.RemoveAt(0);
//        return g;
//    }

//    public KeyValuePair<int, int> top()
//    {
//        KeyValuePair<int, int> g = nowList[0];

//        return g;
//    }

//    public bool empty()
//    {
//        if(nowList.Count == 0)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}

public class dijkstra : MonoBehaviour
{
    [SerializeField]
    private InputField startfield;

    [SerializeField]
    private InputField endfield;

    int start;
    int end;

    int number = 6;
    int INF = 1000000000;

    int[] d=new int[7];
    bool check;
    public Priority_Queue<KeyValuePair<int, int>> pq;// 힙구조 유지

    List<Edge> graph;
    int[] Path;
    void Start()
    {
        Path = new int[7];
        pq = new Priority_Queue<KeyValuePair<int, int>>();
        graph = this.gameObject.GetComponent<Graph>()._edgeList;
        for (int i = 1; i <= number; i++)
        {
            d[i] = INF;
        }
        check = false;

        start = 0;
        end = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Dijkstra(int start)
    {
        d[start] = 0; // 탐색 시작하는 노드의 최소비용은 0
        
        pq.push(new KeyValuePair<int, int>(start,0));

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
                if(graph[i].LeftNode.getNode()==current)
                {
                    // 선택된 노드의 인접노드를 담아줌 
                    int next = graph[i].RightNode.getNode();
                    // 선택된 노드를 거쳐서 인접노드로 가는 비용 계산
                    int nextDistance = distance + graph[i].Weight;

                    // 기존의 비용과 비교
                    if (nextDistance < d[next])
                    {
                        d[next] = nextDistance;
                        pq.push(new KeyValuePair<int, int>(next, -nextDistance));
                        Path[next] = current;
                    }
                }
                
            }

        }
        check = true;
    }

    void BacktrackPath(int[] Path, int end)
    {
        Stack<int> S;
        S = new Stack<int>();

        S.Push(end);
        for(int i=Path[end];i!=0;)
        {
            S.Push(i);
            i = Path[i];
        }

        while (S.Count!=0)
        {
            Debug.Log(S.Peek());         
              
            GameObject pathNode;
            pathNode=GameObject.Find(S.Peek().ToString());
            pathNode.GetComponent<MeshRenderer>().material.color = Color.red;
            
            S.Pop();
        }
    }

    public void startDijkstra()
    {
        start = int.Parse(startfield.text);
        end = int.Parse(endfield.text);

        if (check != true)
        {
            Dijkstra(start);

            Debug.Log(start + "에서" + end + "까지의 비용:" + d[end]);

            BacktrackPath(Path, end);
        }
    }
}
