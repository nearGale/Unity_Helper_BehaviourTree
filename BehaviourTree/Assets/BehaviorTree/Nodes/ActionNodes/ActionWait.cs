using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ActionWait : Action
    {
        private float m_WaitTime = 1f;
        private float m_StartTime;

        public ActionWait(BehaviorTree tree, string name, float time) : base(tree, name)
        {
            m_WaitTime = time;
        }

        protected override BTreeStatus OnUpdate()
        {
            if (m_StartTime == 0)
            {
                m_StartTime = Time.time;
            }

            // 还没有到时间返回running
            if (Time.time > m_StartTime + m_WaitTime)
            {
                Debug.Log("Wait Finished");
                m_StartTime = 0;
                return BTreeStatus.Success;
            }

            Debug.Log("Wait Running");
            return BTreeStatus.Running;
        }
    }
}
