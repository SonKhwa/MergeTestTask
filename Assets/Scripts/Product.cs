namespace miniit.MERGE
{
    public class Product : ColoringStoringObject
    {
        public override void ColorImage()
        {
            image.sprite = StoringObjectInfo.ProductImage;
            image.color = StoringObjectInfo.Color;
        }
    }
}