using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    interface IDelayableDestroyingObject
    {
        abstract IEnumerator DestroyObjectAfterTime(float delayTimeInSeconds);
    }
}
