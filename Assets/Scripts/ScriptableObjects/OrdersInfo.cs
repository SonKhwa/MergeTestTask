using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    [CreateAssetMenu(fileName = "OrdersInfo", menuName = "My Scriptable Objects/OrdersInfo")]
    public class OrdersInfo : ScriptableObject
    {
        [Tooltip("List of orders.")]
        [SerializeField] private List<StoringObjectInfo> orderList = null;

        public List<StoringObjectInfo> GetOrderList()
        {
            return orderList;
        }
    }
}