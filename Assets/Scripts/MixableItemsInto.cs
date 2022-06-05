using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class MixableItemsInto : GrabbableStoringObject
    {
        public override void OnDrop(PointerEventData eventData)
        {
            GameObject other = eventData.pointerDrag;
            if (other is not null && (place.StoringObject is null || other != place.StoringObject.gameObject))
            {
                Item otherItem = other.GetComponent<Item>();
                if (otherItem is not null)
                {
                    if (IsFilled())
                    {
                        Debug.Log("Is filled!");
                        Item thatItem = place.StoringObject.GetComponent<Item>();
                        if (thatItem is null)
                        {
                            Debug.Log("Storing object is not Item!");
                        }
                        else if (TryMixItems(place.StoringObject.GetComponent<Item>(), otherItem) is true)
                        {
                            StoreObject(otherItem);
                        }
                    }
                    else
                    {
                        Debug.Log("Is not filled!");
                        StoreObject(otherItem);
                    }
                }
                else
                {
                    Debug.Log("Both must be items!");
                }
            }
        }

        private bool TryMixItems(Item thatItem, Item otherItem)
        {
            StoringObjectInfo thatobjectInfo = thatItem.StoringObjectInfo;
            StoringObjectInfo otherobjectInfo = otherItem.StoringObjectInfo;

            CombinationInfo combination = TryFindCombination(thatobjectInfo, otherobjectInfo);
            if (combination is null)
            {
                Debug.Log("Not such combination! " + thatobjectInfo.name + " " + otherobjectInfo.name);
                return false;
            }

            Debug.Log("Success combination! " + thatobjectInfo.name + " + " + otherobjectInfo.name + " = " + combination.Result.name);
            MixItems(thatItem, otherItem, combination);
            return true;
        }

        private CombinationInfo TryFindCombination(StoringObjectInfo thatobjectInfo, StoringObjectInfo otherobjectInfo)
        {
            return thatobjectInfo.FindCombination(otherobjectInfo);
        }

        /// <summary>
        /// Destroying item inside the cell and change item in drag to result of their combination.
        /// </summary>
        /// <param name="thatItem">Item inside the cell.</param>
        /// <param name="otherItem">Item in drag.</param>
        /// <param name="combination">Combination of items.</param>
        /// 
        private void MixItems(Item thatItem, Item otherItem, CombinationInfo combination)
        {
            DestroyImmediate(thatItem.gameObject);
            otherItem.StoringObjectInfo = combination.Result;
        }
    }
}
