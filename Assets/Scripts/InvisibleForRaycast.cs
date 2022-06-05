using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class InvisibleForRaycast : MonoBehaviour
    {
        [SerializeField] protected Image image;

        protected void SetRaycastTargetEnabled(bool flag)
        {
            image.raycastTarget = flag;

        }
    }
}
