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

        public Composite(BehaviorTree tree) : base(tree)
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
    }
}