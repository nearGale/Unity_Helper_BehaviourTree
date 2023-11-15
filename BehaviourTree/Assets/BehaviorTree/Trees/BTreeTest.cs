using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class BTreeTest : BehaviorTree
    {
        private bool enableDebug = true;
        public override void OnInit()
        {
            //Sequence rootSeq = new Sequence();
            Selector root = new Selector();
            Sequence seqA = new Sequence();
            Sequence seqB = new Sequence();
            root.AddChild(seqA);
            root.AddChild(seqB);

            seqA.AddChild(new ActionLog("A0"));
            seqA.AddChild(new ConditionFalse());
            seqA.AddChild(new ActionLog("A1"));

            seqB.AddChild(new ActionLog("B0"));
            seqB.AddChild(new ConditionTrue());
            seqB.AddChild(new ActionWait(10f));
            seqB.AddChild(new ActionLog("B1"));

            m_Root = root;
        }
    }
}
