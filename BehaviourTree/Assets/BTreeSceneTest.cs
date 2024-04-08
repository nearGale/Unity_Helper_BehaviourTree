using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BTreeSceneTest : MonoBehaviour
{
    private BTreeTest tree;

    void Start()
    {
        tree = new BTreeTest();
        tree.Tick();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            tree.Tick();
        }
    }
}
