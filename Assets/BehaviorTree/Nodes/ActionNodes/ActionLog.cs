using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ActionLog : Action
    {
        private string logStr = "";
        public ActionLog(string str)
        {
            logStr = str;
        }
        protected override BTreeStatus Update()
        {
            Debug.Log("ActionLog" + logStr);
            return BTreeStatus.Success;
        }
    }
}
