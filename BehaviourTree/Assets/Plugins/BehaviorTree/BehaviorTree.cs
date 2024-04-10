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
            Init();
        }

        private void Init()
        {
            BlackBoard = new();
            BlackBoard.Init();
            OnInit();
        }

        protected abstract void OnInit();

        /// <summary>
        /// 获取树的快照
        /// </summary>
        public void Snapshot()
        {
            string snapshot = "";
            m_Root.GetSnapshot(ref snapshot);
            Debug.Log(snapshot);
        }

        public void Tick()
        {
            m_Root.Tick();

            if (BlackBoard.EnableRunningLog)
            {
                Debug.Log(BlackBoard.GetRunningLog());
                BlackBoard.ClearRunningLog();
            }
        }

        public void Clean()
        {
            m_Root = null;
        }
    }
}