using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public class ItemPlace : MonoBehaviour, IAnchorableItem
    {
        [SerializeField] protected RectTransform rectTransform;
        protected Item storingItem;

        public virtual Item StoringItem
        {
            get => storingItem;
            set
            {
                storingItem = value;
                if (value is not null)
                {
                    storingItem.ItemPlace = this;
                    AnchorItem();
                }
            }
        }

        #region IAnchorableItem implementation

        public void AnchorItem()
        {
            RectTransform otherRect = storingItem.GetComponent<RectTransform>();
            otherRect.position = rectTransform.position;
        }

        #endregion
    }
}