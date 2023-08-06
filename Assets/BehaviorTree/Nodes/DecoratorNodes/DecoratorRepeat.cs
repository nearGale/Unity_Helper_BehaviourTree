using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class DecoratorRepeat : Decorator
    {
        private int m_Count;
        private int m_Limit;

        public DecoratorRepeat(BTreeBehavior child, int limit) : base(child)
        {
            m_Limit = limit;
            m_Count = 0;
        }

        protected override BTreeStatus Update()
        {
            while (true)
            {
                m_Child.Tick();
                if (m_Child.Status == BTreeStatus.Running)
                    break;

                if (m_Child.Status == BTreeStatus.Failure)
                    return BTreeStatus.Failure;

                if (++m_Count == m_Limit)
                    return BTreeStatus.Success;
            }
            return BTreeStatus.Running;
        }
    }
}