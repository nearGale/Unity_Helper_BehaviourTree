using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ConditionFalse : Condition
    {
        protected override BTreeStatus Update()
        {
            Debug.Log("ConditionFalse");
            return BTreeStatus.Failure;
        }
    }
}
