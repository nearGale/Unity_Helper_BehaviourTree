using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public enum BTreeStatus
    {
        Invalid,
        Success,
        Failure,
        Running,
    }

    /// <summary>
    /// 行为树节点基类
    /// </summary>
    public abstract class BTreeBehavior
    {
        /// <summary>
        /// 存在于的行为树
        /// </summary>
        public BehaviorTree BTree;
        protected virtual void OnInitialize() { }
        protected abstract BTreeStatus Update();
        protected virtual void OnTerminate(BTreeStatus status) { }

        public BTreeStatus Status { get { return m_Status; } }
        private BTreeStatus m_Status;

        public BTreeBehavior(BehaviorTree tree)
        {
            BTree = tree;
            m_Status = BTreeStatus.Invalid;
        }

        ~BTreeBehavior()
        {
            BTree = null;
        }

        public BTreeStatus Tick()
        {
            if (IsTerminated())
                OnInitialize();

            m_Status = Update();

            if (IsTerminated())
                OnTerminate(m_Status);

            if (BTree.BlackBoard.EnableRunningLog)
                Debug.Log($"[BTreeNode] {GetClassType()} {m_Status}");
            
            return m_Status;
        }

        public bool IsTerminated()
        {
            return m_Status == BTreeStatus.Success || m_Status == BTreeStatus.Failure || m_Status == BTreeStatus.Invalid;
        }

        public virtual void Abort()
        {
            OnTerminate(BTreeStatus.Failure);
        }

        /// <summary>
        /// 获取子类的类名，用于运行时log输出
        /// </summary>
        /// <returns>子类的类名</returns>
        public string GetClassType()
        {
            return this.GetType().Name;
        }
    }
}
