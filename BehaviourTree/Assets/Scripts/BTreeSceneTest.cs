using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BTreeSceneTest : MonoBehaviour
{
    private BTreeTest tree;
    private BTreeDynamic tree2;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (tree == null)
            {
                tree = new BTreeTest();
            }
            Debug.Log("R");
            tree.Tick();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tree2 == null)
            {
                tree2 = BTreeJsonReader.ReadBTreeJson("BTreeExample");
            }
            Debug.Log("T");
            tree2.Tick();
        }

    }
}
