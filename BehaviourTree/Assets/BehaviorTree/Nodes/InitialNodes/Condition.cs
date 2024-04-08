using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Condition : BTreeBehavior
    {
        protected Condition(BehaviorTree tree) : base(tree)
        {
        }
    }
}