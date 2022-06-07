using UnityEngine;

namespace miniit.MERGE
{
    public class Product : ColoringStoringObject
    {
        [SerializeField] private StoringObject storingObject;

        public override void ColorImage()
        {
            image.sprite = StoringObjectInfo.ProductImage;
            image.color = StoringObjectInfo.Color;
        }

        private void OnDestroy()
        {
            storingObject.FreePlace();
        }
    }
}