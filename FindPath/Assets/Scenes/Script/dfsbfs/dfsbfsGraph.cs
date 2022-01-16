using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dfsbfsGraph : MonoBehaviour
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
    Edge _1_2;
    [SerializeField]
    Edge _1_3;
    [SerializeField]
    Edge _2_4;
    [SerializeField]
    Edge _2_5;
    [SerializeField]
    Edge _3_6;    
    [SerializeField]

    public List<Edge> _edgeList;
    public List<Node> _nodeList;
    // Start is called before the first frame update
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
        _edgeList.Add(_1_2);
        _edgeList.Add(_1_3);
        _edgeList.Add(_2_4);
        _edgeList.Add(_2_5);
        _edgeList.Add(_3_6);
    }
}
