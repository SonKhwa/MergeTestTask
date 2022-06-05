using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class ReturnDraggableWithoutRaycast : DraggableWithoutRaycast
    {
        [SerializeField] private StoringObject storingObject;
        private Vector2 returnPosition;
        private Place previousPlace = null;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            HightlightObject();
            SavePreviousObjectStateAndClear();
        }

        private void SavePreviousObjectStateAndClear()
        {
            SetRaycastTargetEnabled(false);
            returnPosition = rectTransform.anchoredPosition;
            previousPlace = storingObject.Place;
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            ReturnPreviousObjectState();
        }

        private void ReturnPreviousObjectState()
        {
            SetRaycastTargetEnabled(true);
            if (storingObject.Place == previousPlace)
            {
                rectTransform.anchoredPosition = returnPosition;
            }
            else
            {
                ClearPreviousPlace();
            }
        }

        private void ClearPreviousPlace()
        {
            if (previousPlace is not null)
            {
                Debug.Log("Clearing previous place");
                previousPlace.StoringObject = null;
                previousPlace = null;
            }
        }
    }
}
