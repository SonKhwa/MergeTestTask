using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class GrabbableItem : MonoBehaviour, IDropHandler
    {
        [SerializeField] protected ItemPlace itemPlace;

        #region IDropHandler implementation

        public virtual void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            if (eventData.pointerDrag is not null)
            {
                Item item = eventData.pointerDrag.GetComponent<Item>();
                if (item is not null && IsFilled() == false)
                {
                    StoreItem(item);
                }
            }
        }

        #endregion

        protected bool IsFilled()
        {
            return itemPlace.StoringItem is not null;
        }

        protected void StoreItem(Item item)
        {
            itemPlace.StoringItem = item;
        }
    }
}
