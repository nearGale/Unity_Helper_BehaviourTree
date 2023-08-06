using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Composite
    {
        protected int m_CurrentIdx;
        protected override void OnInitialize()
        {
            m_CurrentIdx = 0;
        }

        protected override BTreeStatus Update()
        {
            if (m_Children == null || m_Children.Count == 0)
            {
                return BTreeStatus.Failure;
            }

            for (int i = m_CurrentIdx; i < m_Children.Count; i++)
            {
                BTreeBehavior currentChild = m_Children[i];
                if (currentChild == null)
                    return BTreeStatus.Failure;

                BTreeStatus status = currentChild.Tick();

                switch (status)
                {
                    case BTreeStatus.Failure:
                        break;
                    case BTreeStatus.Running:
                        m_CurrentIdx = i;
                        return status;
                    case BTreeStatus.Success:
                    default:
                        m_CurrentIdx = 0;
                        return status;
                }
            }

            m_CurrentIdx = 0;
            return BTreeStatus.Failure;
        }
    }
}
