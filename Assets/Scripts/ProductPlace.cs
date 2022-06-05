using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ProductPlace : ItemPlace, IConvertableItemToProduct, ICreatable
    {
        [SerializeField] GameObject prefab;

        public override Item StoringItem
        {
            get => storingItem;
            set
            {
                storingItem = value;
                if (value is not null)
                {
                    storingItem.ItemPlace = this;
                    AnchorItem();
                    if (storingItem is not Product)
                    {
                        ChangeItemToProduct();
                    }
                }
            }
        }

        #region IConvertableItemToProduct implementation

        public void ChangeItemToProduct()
        {
            GameObject previousItem = StoringItem.gameObject;
            CreateGameObject();
            DestroyImmediate(previousItem);
        }

        #endregion

        #region ICreatable implementation

        public void CreateGameObject()
        {
            GameObject productInstance = Instantiate(prefab, rectTransform.position, rectTransform.rotation, rectTransform.parent);

            ItemInfo itemInfo = StoringItem.ItemInfo;
            StoringItem = productInstance.GetComponent<Product>();
            StoringItem.ItemInfo = itemInfo;
            StoringItem.ItemPlace = this;
        }

        #endregion
    }
}
