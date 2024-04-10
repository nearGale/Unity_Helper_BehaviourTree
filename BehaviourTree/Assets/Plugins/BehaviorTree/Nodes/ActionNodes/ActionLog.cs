using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ActionLog : Action
    {
        private string logStr = "";

        public ActionLog(BehaviorTree tree, string name, string sParam) : base(tree, name, sParam)
        {
        }

        /// <summary>
        /// 用于自动构造，编辑器生成的json生成自动填参
        /// </summary>
        /// <param name="sParam">param参数</param>
        public override void ParseParam(string sParam)
        {
            base.ParseParam(sParam);
            logStr = sParam;
        }

        protected override BTreeStatus OnUpdate()
        {
            Debug.Log("ActionLog" + logStr);
            return BTreeStatus.Success;
        }
    }
}
