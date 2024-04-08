using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ActionLog : Action
    {
        private string logStr = "";
        
        public ActionLog(BehaviorTree tree, string name, string str) : base(tree, name)
        {
            logStr = str;
        }

        protected override BTreeStatus OnUpdate()
        {
            Debug.Log("ActionLog" + logStr);
            return BTreeStatus.Success;
        }
    }
}
