using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树
    /// </summary>
    public abstract class BehaviorTree
    {
        /// <summary>
        /// 根节点
        /// </summary>
        protected BTreeBehavior m_Root;

        /// <summary>
        /// 是否启用运行时log
        /// </summary>
        protected bool m_EnableRunningLog;

        /// <summary>
        /// 存储树信息、环境信息的黑板
        /// </summary>
        public BTreeBlackBoard BlackBoard;

        public BehaviorTree()
        {
            OnInit();
        }

        public abstract void OnInit();

        public void Tick()
        {
            m_Root.Tick();
        }

        public void Clean()
        {
            m_Root = null;
        }
    }
}