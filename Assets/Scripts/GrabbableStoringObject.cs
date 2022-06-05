using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class GrabbableStoringObject : MonoBehaviour, IDropHandler
    {
        [SerializeField] protected Place place;

        #region IDropHandler implementation

        public virtual void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            if (eventData.pointerDrag is not null)
            {
                StoringObject storingObject = eventData.pointerDrag.GetComponent<StoringObject>();
                if (storingObject is not null && IsFilled() == false)
                {
                    StoreObject(storingObject);
                }
            }
        }

        #endregion

        protected bool IsFilled()
        {
            return place.StoringObject is not null;
        }

        protected void StoreObject(StoringObject storingObject)
        {
            if (storingObject is not null)
            {
                storingObject.FreePlace();
            }

            place.StoringObject = storingObject;
        }
    }
}
