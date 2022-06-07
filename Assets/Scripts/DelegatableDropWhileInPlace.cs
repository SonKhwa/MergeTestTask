using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public abstract class DelegatableDropWhileInPlace<T> : MonoBehaviour, IDropHandler where T : GrabbableStoringObject
    {
        [SerializeField] private StoringObject storingObject;

        #region IPointerExitHandler implementation

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag is not null && storingObject.Place is not null)
            {
                T grabbableStoringObject = storingObject.Place.GetComponent<T>();
                if (grabbableStoringObject is not null) 
                {
                    grabbableStoringObject.OnDrop(eventData);
                }
            }
        }

        #endregion
    }
}
