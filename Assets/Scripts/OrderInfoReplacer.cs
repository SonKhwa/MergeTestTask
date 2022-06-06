using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class OrderInfoReplacer : MonoBehaviour
    {
        [SerializeField] private Image orderImage;
        [SerializeField] private TextMeshProUGUI orderName;

        public void SetOrder(StoringObjectInfo objectInfo)
        {
            orderImage.sprite = objectInfo.ProductImage;
            orderImage.sprite = objectInfo.ProductImage;
            orderName.text = objectInfo.ProductName;
        }

        public void ReactOnWrongProduct()
        {
            Debug.Log("Wrong product!");
        }
    }
}