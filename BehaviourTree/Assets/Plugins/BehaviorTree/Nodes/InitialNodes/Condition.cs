using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Condition : Leaf
    {
        protected Condition(BehaviorTree tree, string name, string sParam) : base(tree, name, sParam)
        {
        }

        protected override void PostUpdate()
        {
            base.PostUpdate();

            if (m_Tree.BlackBoard.EnableRunningLog)
                m_Tree.BlackBoard.AppendRunningLog($"[{m_Name}({GetClassType()}) {m_Status}] ");
        }
    }
}