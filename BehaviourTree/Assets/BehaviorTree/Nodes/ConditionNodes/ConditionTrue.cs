using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ConditionTrue : Condition
    {
        protected override BTreeStatus Update()
        {
            Debug.Log("ConditionTrue");
            return BTreeStatus.Success;
        }
    }
}
