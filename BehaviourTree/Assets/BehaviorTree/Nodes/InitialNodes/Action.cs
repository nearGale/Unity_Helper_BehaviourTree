using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Action : BTreeBehavior
    {
        protected Action(BehaviorTree tree) : base(tree)
        {
        }
    }
}