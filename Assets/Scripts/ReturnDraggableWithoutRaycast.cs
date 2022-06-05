using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class ReturnDraggableWithoutRaycast : DraggableWithoutRaycast
    {
        [SerializeField] private Item item;
        private Vector2 returnPosition;
        private ItemPlace previousCellPlace = null;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            HightlightObject();
            SavePreviousObjectStateAndClear();
        }

        private void SavePreviousObjectStateAndClear()
        {
            SetRaycastTargetEnabled(false);
            returnPosition = rectTransform.anchoredPosition;
            if (item.ItemPlace is not null)
            {
                previousCellPlace = item.ItemPlace;
                item.ItemPlace.StoringItem = null;
                item.ItemPlace = null;
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            ReturnPreviousObjectState();
        }

        private void ReturnPreviousObjectState()
        {
            SetRaycastTargetEnabled(true);
            if (item.ItemPlace is null)
            {
                if (previousCellPlace is not null)
                {
                    item.ItemPlace = previousCellPlace;
                    item.ItemPlace.StoringItem = item;
                }
                rectTransform.anchoredPosition = returnPosition;
            }
        }
    }
}
