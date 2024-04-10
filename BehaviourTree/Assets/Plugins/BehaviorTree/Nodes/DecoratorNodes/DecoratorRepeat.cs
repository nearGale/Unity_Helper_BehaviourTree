using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace BehaviorTree
{
    public class DecoratorRepeat : Decorator
    {
        private int m_Count;
        private int m_Limit;

        public DecoratorRepeat(BehaviorTree tree, string name, BTreeBehavior child, string sParam) : base(tree, name, child, sParam)
        {
            m_Count = 0;
        }

        public override void ParseParam(string sParam)
        {
            base.ParseParam(sParam);
            m_Limit = int.Parse(sParam);
        }

        protected override BTreeStatus OnUpdate()
        {
            if(m_Child == null) 
                return BTreeStatus.Failure;

            for(int i = m_Count; i < m_Limit; i++)
            {
                m_Child.Tick();
                if (m_Child.Status == BTreeStatus.Running)
                {
                    m_Count = i;
                    return BTreeStatus.Running;
                }

                if (m_Child.Status == BTreeStatus.Failure)
                    return BTreeStatus.Failure;
            }
            m_Count = 0;
            return BTreeStatus.Success;
        }
    }
}