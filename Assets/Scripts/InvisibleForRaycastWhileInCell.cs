using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class InvisibleForRaycastWhileInCell : InvisibleForRaycast, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Item item;

        #region IPointerExitHandler implementation

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag is not null && item.ItemPlace is not null)
            {
                SetRaycastTargetEnabled(false);
            } 
        }

        #endregion

        #region IPointerExitHandler implementation

        public void OnPointerExit(PointerEventData eventData)
        {
            if (item.ItemPlace is not null)
            {
                SetRaycastTargetEnabled(true);
            }
        }

        #endregion
    }
}
