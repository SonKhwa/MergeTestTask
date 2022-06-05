using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class Product : Item, IDelayableDestroyingObject
    {
        [SerializeField] float delayTimeInSeconds = 5f;

        protected override void Start()
        {
            ColorImage(itemInfo);
            StartCoroutine(DestroyObjectAfterTime(delayTimeInSeconds));
        }

        #region IDelayableDestroyingObject implementation

        public IEnumerator DestroyObjectAfterTime(float delayTimeInSeconds)
        {
            yield return new WaitForSeconds(delayTimeInSeconds);

            FreeProductPlace();
            DestroyImmediate(gameObject);
        }

        #endregion

        private void FreeProductPlace()
        {
            ItemPlace.StoringItem = null;
        }

        public override void ColorImage(ItemInfo itemInfo)
        {
            image.sprite = itemInfo.ProductImage;
        }
    }
}