using Doozy.Runtime.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace miniit.MERGE
{
    public class MixableItemsInto : GrabbableStoringObject
    {
        [Tooltip("StreamCategory of signal OnMixedItems.")]
        [SerializeField] protected string OnMixedItems = nameof(OnMixedItems);

        [Tooltip("StreamCategory of signal OnMixedItems.")]
        [SerializeField] protected string OnNotGrab = nameof(OnNotGrab);

        public override void OnDrop(PointerEventData eventData)
        {
            GameObject other = eventData.pointerDrag;
            if (other is not null && IsSameObject(other) is false)
            {
                Item otherItem = other.GetComponent<Item>();
                if (otherItem is not null)
                {
                    if (IsFilled())
                    {
                        Item thatItem = place.StoringObject.GetComponent<Item>();
                        if (thatItem is null)
                        {
                            SignalStream.Get(MusicEvents, OnNotGrab).SendSignal();
                            Debug.Log("Storing object is not Item!");
                        }
                        else if (TryMixItems(place.StoringObject.GetComponent<Item>(), otherItem) is true)
                        {
                            SignalStream.Get(MusicEvents, OnMixedItems).SendSignal();
                            StoreObject(otherItem);
                        } 
                        else
                        {
                            SignalStream.Get(MusicEvents, OnNotGrab).SendSignal();
                        }
                    }
                    else
                    {
                        SignalStream.Get(MusicEvents, OnGrabObject).SendSignal();
                        Debug.Log("Storing item!");
                        StoreObject(otherItem);
                    }
                }
                else
                {
                    Debug.Log("Both must be items!");
                }
            }
        }

        private bool IsSameObject(GameObject other)
        {
            return (place.StoringObject is not null && other == place.StoringObject.gameObject);
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

        private void MixItems(Item thatItem, Item otherItem, CombinationInfo combination)
        {
            Destroy(thatItem.gameObject);
            thatItem.FreePlace();
            otherItem.StoringObjectInfo = combination.Result;
        }
    }
}
