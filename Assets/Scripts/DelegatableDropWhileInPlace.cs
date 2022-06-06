using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class DelegatableDropWhileInPlace : MonoBehaviour, IDropHandler
    {
        [SerializeField] private StoringObject storingObject;

        #region IPointerExitHandler implementation

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag is not null && storingObject.Place is not null)
            {
                MixableItemsInto mixableItemsInto = storingObject.Place.GetComponent<MixableItemsInto>();
                if (mixableItemsInto is not null) 
                { 
                    mixableItemsInto.OnDrop(eventData);
                }
            } 
        }

        #endregion
    }
}
