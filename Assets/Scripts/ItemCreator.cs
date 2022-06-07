using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ItemCreator : MonoBehaviour, IColorableByStoringObjectInfo, ICreatable<Item>
    {
        [SerializeField] private Image image;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private RectTransform ItemContainerAsParent;
        [SerializeField] private Item prefab;
        [SerializeField] private StoringObjectInfo objectInfo;
        [SerializeField] private float intensity = 0.5f;

        private void Start()
        {
            ColorImage();
        }

        public void CreateItem()
        {
            CreateGameObject();
        }

        #region ICreatable implementation

        public Item CreateGameObject()
        {
            Item itemInstance = Instantiate<Item>(prefab, rectTransform.position, rectTransform.rotation, ItemContainerAsParent);
            itemInstance.StoringObjectInfo = objectInfo;
            return itemInstance;
        }

        #endregion

        #region IColorableByStoringObjectInfo implementation

        public void ColorImage()
        {
            if (image is not null)
            {
                image.color = objectInfo.Color;
                image.color *= new Vector4 (1, 1, 1, intensity);
            }
        }

        #endregion
    }
}