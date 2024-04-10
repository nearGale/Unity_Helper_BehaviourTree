using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Filter : Sequence
    {
        public Filter(BehaviorTree tree, string name) : base(tree, name)
        {
        }

        public void AddCondition(BTreeBehavior condition)
        {
            m_Children.Insert(0, condition);
        }

        public void AddAction(BTreeBehavior action)
        {
            m_Children.Add(action);
        }
    }
}