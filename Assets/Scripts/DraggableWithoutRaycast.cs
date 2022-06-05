using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class DraggableWithoutRaycast : InvisibleForRaycast, IKeepableInsideSceen, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] protected RectTransform rectTransform;
        private Canvas canvas;
        private Vector2 previousPosition;

        private void OnEnable()
        {
            canvas = GetCanvas();
        }

        private Canvas GetCanvas()
        {
            canvas = rectTransform.root.GetComponent<Canvas>();
            if (canvas is null)
                throw new System.Exception("root is not a Canvas!");

            return canvas;
        }

        #region IBeginDragHandler implementation

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            SetRaycastTargetEnabled(false);
            HightlightObject();
        }

        #endregion

        protected void HightlightObject()
        {
            rectTransform.SetAsLastSibling();
        }

        #region IDragHandler implementation

        public void OnDrag(PointerEventData eventData)
        {
            if (IKeepableInsideSceen.IsInsideScreen(rectTransform))
            {
                SavePreviousPosition();
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
            else
            {
                rectTransform.anchoredPosition = previousPosition;
            }
        }

        #endregion

        #region IEndDragHandler implementation

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            SetRaycastTargetEnabled(true);
        }

        #endregion

        #region IKeepableInsideSceen implementation

        public void SavePreviousPosition()
        {
            previousPosition = rectTransform.anchoredPosition;
        }

        #endregion
    }
}