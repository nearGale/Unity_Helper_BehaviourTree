using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTree
    {
        protected BTreeBehavior m_Root;

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