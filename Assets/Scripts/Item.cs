using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class Item : MonoBehaviour, IColorableByItem
    {
        [SerializeField] protected Image image;
        [SerializeField] protected ItemInfo itemInfo;
        protected ItemPlace itemPlace = null;

        public ItemInfo ItemInfo
        {
            get => itemInfo;
            set
            {
                itemInfo = value;
                ColorImage(itemInfo);
            }
        }

        public ItemPlace ItemPlace
        {
            get => itemPlace;
            set => itemPlace = value;
        }

        protected virtual void Start()
        {
            ColorImage(itemInfo);
        }

        #region IColorableByItem implementation

        public virtual void ColorImage(ItemInfo itemInfo)
        {
            image.color = itemInfo.Color;
        }

        #endregion
    }
}