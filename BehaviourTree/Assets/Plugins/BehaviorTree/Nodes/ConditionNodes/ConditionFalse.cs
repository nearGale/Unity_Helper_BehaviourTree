using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ConditionFalse : Condition
    {
        public ConditionFalse(BehaviorTree tree, string name, string sParam) : base(tree, name, sParam)
        {
        }

        protected override BTreeStatus OnUpdate()
        {
            Debug.Log("ConditionFalse");
            return BTreeStatus.Failure;
        }
    }
}
