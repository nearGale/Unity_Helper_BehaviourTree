using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BTreeSceneTest : MonoBehaviour
{
    private BTreeTest tree;
    private float tickInterval = 3;
    private float lastTickTime = 0;

    void Start()
    {
        tree = new BTreeTest();
        tree.Tick();
    }

    void Update()
    {
        //CheckTick();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            tree.Tick();
        }
    }

    private void CheckTick()
    {
        if (Time.time - lastTickTime > tickInterval)
        {
            tree.Tick();
            lastTickTime = Time.time;
        }
    }
}
