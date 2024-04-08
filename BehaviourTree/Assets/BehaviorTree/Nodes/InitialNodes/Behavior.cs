using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        protected BehaviorTree m_Tree;

        /// <summary>
        /// 用于辨认的名称
        /// </summary>
        protected string m_Name;

        protected virtual void OnInitialize() { }
        protected virtual void PreUpdate() { }
        protected abstract BTreeStatus OnUpdate();
        protected virtual void PostUpdate() { }
        protected virtual void OnTerminate(BTreeStatus status) { }

        public BTreeStatus Status { get { return m_Status; } }
        protected BTreeStatus m_Status;

        public BTreeBehavior(BehaviorTree tree, string name)
        {
            m_Tree = tree;
            m_Name = name;
            m_Status = BTreeStatus.Invalid;
        }

        ~BTreeBehavior()
        {
            m_Tree = null;
            m_Name = null;
        }

        public BTreeStatus Tick()
        {
            if (IsTerminated())
                OnInitialize();

            PreUpdate();

            m_Status = OnUpdate();

            PostUpdate();

            if (IsTerminated())
                OnTerminate(m_Status);

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
