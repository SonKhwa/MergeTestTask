using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    interface IKeepableInsideSceen
    {
        public static bool IsInsideScreen(Transform checkableObject)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(checkableObject.position);
            return !(point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f);
        }

        abstract void SavePreviousPosition();
    }
}