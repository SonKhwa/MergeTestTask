using Doozy.Runtime.Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ProductPlace : ConvertablePlace<Product>, ICheckableOrderCompleted
    {
        [Tooltip("StreamCategory of signal OnLevelCompleted.")]
        [SerializeField] private string LevelEvents = nameof(LevelEvents);

        [Tooltip("StreamCategory of signal OnLevelCompleted.")]
        [SerializeField] private string OnLevelCompleted = nameof(OnLevelCompleted);
        [SerializeField] private OrdersInfo ordersInfo;
        [SerializeField] private IntVariable remainOrders;
        [SerializeField] private OrderInfoReplacer replacer;

        private void Awake()
        {
            remainOrders.Value = ordersInfo.GetOrderList().Count;
        }

        private void Start()
        {
            replacer.SetOrder(ordersInfo.GetOrderList()[remainOrders.Value - 1]);
        }

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
                    else
                    {
                        Debug.Log("Check " + storingObject + " Product!");
                        CheckProduct();
                    }
                }
            }
        }

        private void CheckProduct()
        {
            if (IsOrdered())
            {
                SetNextOrder();
                if (IsOrdersCompleted() is false)
                {
                    replacer.SetOrder(ordersInfo.GetOrderList()[remainOrders.Value - 1]);
                    replacer.ReactOnCorrectProduct(storingObject.StoringObjectInfo);
                }
                else
                {
                    SignalStream.Get(LevelEvents, OnLevelCompleted).SendSignal();
                    Debug.Log("Game Over! Level completed!");
                }
            }
            else
            {
                replacer.ReactOnWrongProduct(storingObject.StoringObjectInfo);
            }
        }

        #region ICheckableOrderCompleted implementation

        public bool IsOrdered()
        {
            StoringObjectInfo order = ordersInfo.GetOrderList()[remainOrders.Value - 1];
            return order == storingObject.StoringObjectInfo;
        }

        public bool IsOrdersCompleted()
        {
            return remainOrders.Value == 0;
        }

        public void SetNextOrder()
        {
            remainOrders.Value -= 1;
        }

        #endregion
    }
}
