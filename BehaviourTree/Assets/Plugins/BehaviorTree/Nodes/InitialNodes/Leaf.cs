using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 叶子节点
    /// </summary>
    public abstract class Leaf : BTreeBehavior
    {
        public Leaf(BehaviorTree tree, string name, string sParam) : base(tree, name)
        {
            ParseParam(sParam);
        }

        /// <summary>
        /// 填入参数
        /// </summary>
        /// <param name="sParam">param参数</param>
        public virtual void ParseParam(string sParam)
        {

        }
    }
}