using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 组合节点（顺序节点、选择节点的基类）
    /// </summary>
    public abstract class Composite : BTreeBehavior
    {
        protected List<BTreeBehavior> m_Children;

        public Composite(BehaviorTree tree, string name) : base(tree, name)
        {
            m_Children = new List<BTreeBehavior>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }

        ~Composite()
        {
            m_Children.Clear();
            m_Children = null;
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();

            if (m_Tree.BlackBoard.EnableRunningLog)
                m_Tree.BlackBoard.AppendRunningLog($"{m_Name}({GetClassType()}) -> ");
        }

        public void AddChild(BTreeBehavior behavior)
        {
            m_Children.Add(behavior);
        }

        public void RemoveChild(BTreeBehavior behavior)
        {
            m_Children.Remove(behavior);
        }

        public void ClearChildren()
        {
            m_Children.Clear();
        }

        public override void GetSnapshot(ref string snapshot)
        {
            snapshot += m_Name + $"({this.GetType().Name})" + ":{\n";

            foreach(var child in m_Children)
            {
                child.GetSnapshot(ref snapshot);
                snapshot += "\n";
            }

            snapshot += "}\n";
        }
    }
}