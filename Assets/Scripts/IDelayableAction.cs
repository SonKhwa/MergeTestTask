using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    interface IDelayableAction
    {
        abstract IEnumerator DoActionAfterTime(float delayTimeInSeconds);
        abstract void BeginDoingAction();
        abstract void StopDoingAction();
    }
}
