using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public abstract class StoringObject : MonoBehaviour
    {
        [SerializeField] protected StoringObjectInfo storingObjectInfo;

        [Tooltip("Visible for debugging.")]
        [SerializeField] protected Place place = null;

        public virtual StoringObjectInfo StoringObjectInfo
        {
            get => storingObjectInfo;
            set => storingObjectInfo = value;
        }

        public virtual Place Place
        {
            get => place;
            set => place = value;
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy!");
            FreePlace();
        }

        private void FreePlace()
        {
            if (Place is not null)
            {
                Place.StoringObject = null;
            }
        }
    }
}