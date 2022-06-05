using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public abstract class Place : MonoBehaviour, IAnchorableItem
    {
        [SerializeField] protected RectTransform rectTransform;

        [Tooltip("Visible for debugging.")]
        [SerializeField] protected StoringObject storingObject = null;

        public virtual StoringObject StoringObject
        {
            get => storingObject;
            set
            {
                storingObject = value;
                if (value is not null)
                {
                    storingObject.Place = this;
                    AnchorItem();
                }
            }
        }

        #region IAnchorableItem implementation

        public void AnchorItem()
        {
            RectTransform otherRect = storingObject.GetComponent<RectTransform>();
            otherRect.position = rectTransform.position;
        }

        #endregion
    }
}