using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Decorator : BTreeBehavior
    {
        protected BTreeBehavior m_Child;
        public Decorator(BehaviorTree tree, string name, BTreeBehavior child, string sParam) : base(tree, name)
        {
            m_Child = child;
            ParseParam(sParam);
        }

        /// <summary>
        /// 填入参数
        /// </summary>
        /// <param name="sParam">param参数</param>
        public virtual void ParseParam(string sParam) { }

        protected override void PreUpdate()
        {
            base.PreUpdate();

            if (m_Tree.BlackBoard.EnableRunningLog)
                m_Tree.BlackBoard.AppendRunningLog($"{m_Name}({GetClassType()}) -> ");
        }

        public override void GetSnapshot(ref string snapshot)
        {
            snapshot += m_Name + $"({this.GetType().Name}) -> ";

            m_Child.GetSnapshot(ref snapshot);
        }
    }
}