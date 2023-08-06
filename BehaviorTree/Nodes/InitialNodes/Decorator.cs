using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Decorator : BTreeBehavior
    {
        protected BTreeBehavior m_Child;
        public Decorator(BTreeBehavior child)
        {
            m_Child = child;
        }
    }
}