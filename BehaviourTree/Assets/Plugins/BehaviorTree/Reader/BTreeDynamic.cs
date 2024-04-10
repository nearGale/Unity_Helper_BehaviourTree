using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 通过Json动态生成的行为树
    /// </summary>
    public class BTreeDynamic : BehaviorTree
    {
        public void CreateDynamic(Selector root, bool runningLog)
        {
            BlackBoard.EnableRunningLog = runningLog;
            m_Root = root;
        }

        protected override void OnInit()
        {
        }
    }
}