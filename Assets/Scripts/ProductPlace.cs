using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ProductPlace : ConvertablePlace<Product> 
    {
        public override StoringObject StoringObject
        {
            get => storingObject;
            set
            {
                storingObject = value;
                if (value is not null)
                {
                    storingObject.Place = this;
                    AnchorItem();

                    if (storingObject is not Product)
                    {
                        Debug.Log("Converting " + storingObject + " to " + " Product!");
                        ConvertObject();
                    }
                }
            }
        }
    }
}
