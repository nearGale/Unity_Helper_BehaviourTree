using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Decorator : BTreeBehavior
    {
        protected BTreeBehavior m_Child;
        public Decorator(BehaviorTree tree, BTreeBehavior child) : base(tree)
        {
            m_Child = child;
        }
    }
}