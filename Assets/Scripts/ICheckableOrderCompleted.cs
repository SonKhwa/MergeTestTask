using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    interface ICheckableOrderCompleted
    {
        abstract bool IsOrdered();
        abstract bool IsOrdersCompleted();
        abstract void SetNextOrder();
    }
}
