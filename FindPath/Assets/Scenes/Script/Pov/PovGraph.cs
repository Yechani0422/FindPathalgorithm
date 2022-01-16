using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovGraph : MonoBehaviour
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
    Node _7node;
    [SerializeField]
    Node _8node;
    [SerializeField]
    Node _9node;
    [SerializeField]
    Node _10node;
    [SerializeField]
    Node _11node;
    [SerializeField]
    Node _12node;
    [SerializeField]
    Node _13node;
    [SerializeField]
    Node _14node;
    [SerializeField]
    Node _15node;
    [SerializeField]
    Node _16node;
    [SerializeField]
    Node _17node;
    [SerializeField]
    Node _18node;
    [SerializeField]
    Node _19node;
    [SerializeField]
    Node _20node;


    [SerializeField]
    Edge _1_7_10;
    [SerializeField]
    Edge _7_1_10;

    [SerializeField]
    Edge _1_3_8;
    [SerializeField]
    Edge _3_1_8;

    [SerializeField]
    Edge _1_2_7;
    [SerializeField]
    Edge _2_1_7;

    [SerializeField]
    Edge _1_9_9;
    [SerializeField]
    Edge _9_1_9;

    [SerializeField]
    Edge _8_9_2;
    [SerializeField]
    Edge _9_8_2;

    [SerializeField]
    Edge _7_8_2;
    [SerializeField]
    Edge _8_7_2;

    [SerializeField]
    Edge _7_17_3;
    [SerializeField]
    Edge _17_7_3;

    [SerializeField]
    Edge _16_17_4;
    [SerializeField]
    Edge _17_16_4;

    [SerializeField]
    Edge _15_16_5;
    [SerializeField]
    Edge _16_15_5;

    [SerializeField]
    Edge _8_15_4;
    [SerializeField]
    Edge _15_8_4;

    [SerializeField]
    Edge _14_15_5;
    [SerializeField]
    Edge _15_14_5;

    [SerializeField]
    Edge _13_14_2;
    [SerializeField]
    Edge _14_13_2;

    [SerializeField]
    Edge _13_20_2;
    [SerializeField]
    Edge _20_13_2;

    [SerializeField]
    Edge _11_14_4;
    [SerializeField]
    Edge _14_11_4;

    [SerializeField]
    Edge _10_11_3;
    [SerializeField]
    Edge _11_10_3;

    [SerializeField]
    Edge _11_12_3;
    [SerializeField]
    Edge _12_11_3;

    [SerializeField]
    Edge _12_13_6;
    [SerializeField]
    Edge _13_12_6;

    [SerializeField]
    Edge _12_19_6;
    [SerializeField]
    Edge _19_12_6;

    [SerializeField]
    Edge _2_3_2;
    [SerializeField]
    Edge _3_2_2;

    [SerializeField]
    Edge _2_4_2;
    [SerializeField]
    Edge _4_2_2;

    [SerializeField]
    Edge _4_10_2;
    [SerializeField]
    Edge _10_4_2;

    [SerializeField]
    Edge _5_18_2;
    [SerializeField]
    Edge _18_5_2;

    [SerializeField]
    Edge _5_6_2;
    [SerializeField]
    Edge _6_5_2;

    [SerializeField]
    Edge _6_11_2;
    [SerializeField]
    Edge _11_6_2;

    [SerializeField]
    Edge _6_12_3;
    [SerializeField]
    Edge _12_6_3;

    [SerializeField]
    Edge _3_18_4;
    [SerializeField]
    Edge _18_3_4;

    [SerializeField]
    Edge _2_5_4;
    [SerializeField]
    Edge _5_2_4;

    [SerializeField]
    Edge _4_6_4;
    [SerializeField]
    Edge _6_4_4;

    [SerializeField]
    Edge _18_19_3;
    [SerializeField]
    Edge _19_18_3;

    [SerializeField]
    Edge _9_11_6;
    [SerializeField]
    Edge _11_9_6;

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
        _nodeList.Add(_7node);
        _nodeList.Add(_8node);
        _nodeList.Add(_9node);
        _nodeList.Add(_10node);
        _nodeList.Add(_11node);
        _nodeList.Add(_12node);
        _nodeList.Add(_13node);
        _nodeList.Add(_14node);
        _nodeList.Add(_15node);
        _nodeList.Add(_16node);
        _nodeList.Add(_17node);
        _nodeList.Add(_18node);
        _nodeList.Add(_19node);
        _nodeList.Add(_20node);
    }

    void MakeGraph()
    {
        _edgeList.Add(_1_7_10);
        _edgeList.Add(_7_1_10);

        _edgeList.Add(_1_3_8);
        _edgeList.Add(_3_1_8);

        _edgeList.Add(_1_2_7);
        _edgeList.Add(_2_1_7);

        _edgeList.Add(_1_9_9);
        _edgeList.Add(_9_1_9);

        _edgeList.Add(_8_9_2);
        _edgeList.Add(_9_8_2);

        _edgeList.Add(_7_8_2);
        _edgeList.Add(_8_7_2);

        _edgeList.Add(_7_17_3);
        _edgeList.Add(_17_7_3);

        _edgeList.Add(_16_17_4);
        _edgeList.Add(_17_16_4);

        _edgeList.Add(_15_16_5);
        _edgeList.Add(_16_15_5);

        _edgeList.Add(_8_15_4);
        _edgeList.Add(_15_8_4);

        _edgeList.Add(_14_15_5);
        _edgeList.Add(_15_14_5);

        _edgeList.Add(_13_14_2);
        _edgeList.Add(_14_13_2);

        _edgeList.Add(_13_20_2);
        _edgeList.Add(_20_13_2);

        _edgeList.Add(_11_14_4);
        _edgeList.Add(_14_11_4);

        _edgeList.Add(_10_11_3);
        _edgeList.Add(_11_10_3);

        _edgeList.Add(_11_12_3);
        _edgeList.Add(_12_11_3);

        _edgeList.Add(_12_13_6);
        _edgeList.Add(_13_12_6);

        _edgeList.Add(_12_19_6);
        _edgeList.Add(_19_12_6);

        _edgeList.Add(_2_3_2);
        _edgeList.Add(_3_2_2);

        _edgeList.Add(_2_4_2);
        _edgeList.Add(_4_2_2);

        _edgeList.Add(_4_10_2);
        _edgeList.Add(_10_4_2);

        _edgeList.Add(_5_18_2);
        _edgeList.Add(_18_5_2);

        _edgeList.Add(_5_6_2);
        _edgeList.Add(_6_5_2);

        _edgeList.Add(_6_11_2);
        _edgeList.Add(_11_6_2);

        _edgeList.Add(_6_12_3);
        _edgeList.Add(_12_6_3);

        _edgeList.Add(_3_18_4);
        _edgeList.Add(_18_3_4);

        _edgeList.Add(_2_5_4);
        _edgeList.Add(_5_2_4);

        _edgeList.Add(_4_6_4);
        _edgeList.Add(_6_4_4);

        _edgeList.Add(_18_19_3);
        _edgeList.Add(_19_18_3);

        _edgeList.Add(_9_11_6);
        _edgeList.Add(_11_9_6);
    }
}
