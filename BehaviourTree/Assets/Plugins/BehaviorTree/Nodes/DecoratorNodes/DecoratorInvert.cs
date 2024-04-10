using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

    public class DecoratorInvert : Decorator
    {
        public DecoratorInvert(BehaviorTree tree, string name, BTreeBehavior child) : base(tree, name, child)
        {
        }

        protected override BTreeStatus OnUpdate()
        {
            if (m_Child == null) { return BTreeStatus.Failure; }

            BTreeStatus status = m_Child.Tick();

            if (status == BTreeStatus.Success)
            {
                return BTreeStatus.Failure;
            }

            if (status == BTreeStatus.Failure)
            {
                return BTreeStatus.Success;
            }

            return status;
        }
    }
}