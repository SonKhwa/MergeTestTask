using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    [CreateAssetMenu(fileName = "ItemInfo", menuName = "My Scriptable Objects/ItemInfo")]
    public class ItemInfo : ScriptableObject
    {
        [SerializeField] private int level = 1;
        [SerializeField] private Color color = Color.black;
        [SerializeField] private string productName = "product name";
        [SerializeField] private Sprite productImage;

        [Tooltip("The combinations of item.")]
        public List<CombinationInfo> combinations = null;

        public int Level
        {
            get => level;
            set => level = value;
        }

        public Color Color
        {
            get => color;
            set => color = value;
        }

        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        public Sprite ProductImage
        {
            get => productImage;
            set => productImage = value;
        }

        public CombinationInfo FindCombination(ItemInfo otherItem)
        {
            foreach (CombinationInfo combination in combinations)
            {
                if (combination.Equals(new ItemInfo[2] {this, otherItem}))
                {
                    return combination;
                }
            }
            return null;
        }
    }
}
