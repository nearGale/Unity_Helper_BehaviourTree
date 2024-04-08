using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ConditionTrue : Condition
    {
        public ConditionTrue(BehaviorTree tree, string name) : base(tree, name)
        {
        }

        protected override BTreeStatus OnUpdate()
        {
            Debug.Log("ConditionTrue");
            return BTreeStatus.Success;
        }
    }
}
