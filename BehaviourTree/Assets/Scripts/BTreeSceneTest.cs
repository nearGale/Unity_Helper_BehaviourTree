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
                Debug.Log("代码生成行为树...");
                tree = new BTreeTest();
                Debug.Log("生成完成：");
                tree.Snapshot();
            }
            else
            {
                Debug.Log("运行行为树：");
                tree.Tick();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tree2 == null)
            {
                Debug.Log("读取Json生成树...");
                tree2 = BTreeJsonReader.ReadBTreeJson("BTreeExample");
                Debug.Log("生成完成：");
                tree2.Snapshot();
            }
            else
            {
                Debug.Log("运行行为树：");
                tree2.Tick();
            }
        }

    }
}
