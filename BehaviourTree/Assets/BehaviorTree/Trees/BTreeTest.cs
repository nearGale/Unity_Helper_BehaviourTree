using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class BTreeTest : BehaviorTree
    {
        protected override void OnInit()
        {
            BlackBoard.EnableRunningLog = true;

            Selector root = new Selector(this, "root");
            Sequence seqA = new Sequence(this, "A分支");
            Sequence seqB = new Sequence(this, "B分支");
            root.AddChild(seqA);
            root.AddChild(seqB);

            seqA.AddChild(new ActionLog(this, "A-打印0", "A0"));
            seqA.AddChild(new ConditionFalse(this, "A-不通过"));
            seqA.AddChild(new ActionLog(this, "A-打印1", "A1"));

            seqB.AddChild(new ActionLog(this, "B-打印0", "B0"));
            seqB.AddChild(new ConditionTrue(this, "B-通过"));
            seqB.AddChild(new ActionWait(this, "B-等待10秒", 10f));
            seqB.AddChild(new ActionLog(this, "B-打印1", "B1"));

            m_Root = root;
        }
    }
}
