using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Node _1node;
    [SerializeField]
    Node _2node;
    [SerializeField]
    Node _3node;
    [SerializeField]
    Node _4node;
    [SerializeField]
    Node _5node;
    [SerializeField]
    Node _6node;

    [SerializeField]
    Edge _1_2_2;
    [SerializeField]
    Edge _1_3_5;
    [SerializeField]
    Edge _1_4_1;
    [SerializeField]
    Edge _2_1_2;
    [SerializeField]
    Edge _2_3_3;
    [SerializeField]
    Edge _2_4_2;
    [SerializeField]
    Edge _3_1_5;
    [SerializeField]
    Edge _3_2_3;
    [SerializeField]
    Edge _3_4_3;
    [SerializeField]
    Edge _3_5_1;
    [SerializeField]
    Edge _3_6_5;
    [SerializeField]
    Edge _4_1_1;
    [SerializeField]
    Edge _4_2_2;
    [SerializeField]
    Edge _4_3_3;
    [SerializeField]
    Edge _4_5_1;
    [SerializeField]
    Edge _5_3_1;
    [SerializeField]
    Edge _5_4_1;
    [SerializeField]
    Edge _5_6_2;
    [SerializeField]
    Edge _6_3_5;
    [SerializeField]
    Edge _6_5_2;


    public List<Edge> _edgeList;
    public List<Node> _nodeList;
    void Start()
    {
        MakeGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddNode()
    {
        _nodeList.Add(_1node);
        _nodeList.Add(_2node);
        _nodeList.Add(_3node);
        _nodeList.Add(_4node);
        _nodeList.Add(_5node);
        _nodeList.Add(_6node);
    }

    void MakeGraph()
    {
        _edgeList.Add(_1_2_2);
        _edgeList.Add(_1_3_5);
        _edgeList.Add(_1_4_1);

        _edgeList.Add(_2_1_2);
        _edgeList.Add(_2_3_3);
        _edgeList.Add(_2_4_2);

        _edgeList.Add(_3_1_5);
        _edgeList.Add(_3_2_3);
        _edgeList.Add(_3_4_3);
        _edgeList.Add(_3_5_1);
        _edgeList.Add(_3_6_5);

        _edgeList.Add(_4_1_1);
        _edgeList.Add(_4_2_2);
        _edgeList.Add(_4_3_3);
        _edgeList.Add(_4_5_1);

        _edgeList.Add(_5_3_1);
        _edgeList.Add(_5_4_1);
        _edgeList.Add(_5_6_2);

        _edgeList.Add(_6_3_5);
        _edgeList.Add(_6_5_2);
    }
}
