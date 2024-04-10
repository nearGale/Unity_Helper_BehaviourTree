using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Decorator : BTreeBehavior
    {
        protected BTreeBehavior m_Child;
        public Decorator(BehaviorTree tree, string name, BTreeBehavior child) : base(tree, name)
        {
            m_Child = child;
        }
    }
}