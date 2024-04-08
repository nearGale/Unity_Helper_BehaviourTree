using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树的黑板，存储一些树信息、环境信息
    /// </summary>
    public class BTreeBlackBoard
    {
        /// <summary>
        /// 是否记录运行时log
        /// </summary>
        public bool EnableRunningLog;

        /// <summary>
        /// 运行时log的缓存
        /// </summary>
        private string m_RunningLog = string.Empty;

        public void Init()
        {
            EnableRunningLog = false;
            m_RunningLog = string.Empty;
        }

        /// <summary>
        /// 拼接运行时log
        /// </summary>
        public void AppendRunningLog(string subStr)
        {
            m_RunningLog += subStr;
        }

        public void ClearRunningLog()
        {
            m_RunningLog = string.Empty;
        }

        public string GetRunningLog()
        {
            return "[BTree] " + m_RunningLog;
        }
    }
}