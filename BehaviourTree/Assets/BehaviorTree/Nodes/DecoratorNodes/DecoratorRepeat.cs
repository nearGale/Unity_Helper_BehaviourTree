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
            if(m_Child == null) return BTreeStatus.Failure;

            for(int i = m_Count; i < m_Limit; i++)
            {
                m_Child.Tick();
                if (m_Child.Status == BTreeStatus.Running)
                {
                    m_Count = i;
                    return BTreeStatus.Running;
                }

                if (m_Child.Status == BTreeStatus.Failure)
                    return BTreeStatus.Failure;
            }
            m_Count = 0;
            return BTreeStatus.Success;
        }
    }
}