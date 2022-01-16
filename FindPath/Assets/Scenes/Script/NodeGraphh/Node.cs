using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    public int _nodeNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNode()
    {
        return _nodeNum;
    }
}
