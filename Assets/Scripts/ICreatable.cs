using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    interface ICreatable<T>
    {
        abstract T CreateGameObject();
    }
}
