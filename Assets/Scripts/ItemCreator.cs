using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ItemCreator : MonoBehaviour, IColorableByItem, ICreatable
    {
        [SerializeField] private Image image;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private RectTransform ItemContainerAsParent;
        [SerializeField] private GameObject prefab;
        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private float intensity = 0.5f;

        private void Start()
        {
            ColorImage(itemInfo);
        }

        #region ICreatable implementation

        public void CreateGameObject()
        {
            GameObject itemInstance = Instantiate(prefab, rectTransform.position, rectTransform.rotation, ItemContainerAsParent);
            itemInstance.GetComponent<Item>().ItemInfo = itemInfo;
        }

        #endregion

        #region IColorableByItem implementation

        public void ColorImage(ItemInfo itemInfo)
        {
            if (image is not null)
            {
                image.color = itemInfo.Color;
                image.color *= new Vector4 (1, 1, 1, intensity);
            }
        }

        #endregion
    }
}