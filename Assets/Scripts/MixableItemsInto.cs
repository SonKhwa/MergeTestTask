using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class MixableItemsInto : GrabbableItem
    {
        public override void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            GameObject other = eventData.pointerDrag;
            if (other is not null)
            {
                Item otherItem = other.GetComponent<Item>();
                if (otherItem is not null)
                {
                    if (IsFilled())
                    {
                        Debug.Log("Is filled!");
                        if (TryMixItems(itemPlace.StoringItem, otherItem) == false)
                        {
                            return;
                        }
                    }

                    Debug.Log("Is not filled!");
                    StoreItem(otherItem);
                }
            }
        }

        private bool TryMixItems(Item thatItem, Item otherItem)
        {
            ItemInfo thatItemInfo = thatItem.ItemInfo;
            ItemInfo otherItemInfo = otherItem.ItemInfo;

            CombinationInfo combination = TryFindCombination(thatItemInfo, otherItemInfo);
            if (combination is null)
            {
                Debug.Log("Not such combination! " + thatItemInfo.name + " " + otherItemInfo.name);
                return false;
            }

            Debug.Log("Success combination! " + thatItemInfo.name + " + " + otherItemInfo.name + " = " + combination.Result.name);
            MixItems(thatItem, otherItem, combination);
            return true;
        }

        private CombinationInfo TryFindCombination(ItemInfo thatItemInfo, ItemInfo otherItemInfo)
        {
            return thatItemInfo.FindCombination(otherItemInfo);
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
            ChangeItemInfo(otherItem, combination.Result);
        }

        private void ChangeItemInfo(Item otherItem, ItemInfo result)
        {
            otherItem.ItemInfo = result;
        }
    }
}
