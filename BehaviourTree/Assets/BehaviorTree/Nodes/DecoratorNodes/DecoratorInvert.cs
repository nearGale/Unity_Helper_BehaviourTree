using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

    public class DecoratorInvert : Decorator
    {
        public DecoratorInvert(BTreeBehavior child) : base(child)
        {
        }

        protected override BTreeStatus Update()
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