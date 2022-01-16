using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField]
    Node _leftNode;
    [SerializeField]
    Node _rightNode;
    [SerializeField]
    int _weight;

    public Edge(Node lNode, Node rNode,int w)
    {
        _leftNode=lNode;
        _rightNode=rNode;
        _weight=w;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Node LeftNode
    {
        get
        {
            return _leftNode;
        }
        set
        {
            _leftNode = value;
        }
    }

    public Node RightNode
    {
        get
        {
            return _rightNode;
        }
        set
        {
            _rightNode = value;
        }
    }

    public int Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;
        }
    }
}
