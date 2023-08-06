using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    enum ENodeType
    {
        // Normal
        Selector,
        Sequence,
        ActiveSelector,

        // Condition
        IsAlive,

        // Action
    }
}
