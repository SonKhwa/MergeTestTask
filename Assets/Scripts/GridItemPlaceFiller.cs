using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class GridItemPlaceFiller : MonoBehaviour, ICreatable<ItemPlace>
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;

        [Tooltip("Parent for itemPlace instances.")]
        [SerializeField] private RectTransform gridContainerAsParent;

        [Tooltip("Parent for creatures of itemPlace.")]
        [SerializeField] private RectTransform itemContainerAsParent;
        [SerializeField] private ItemPlace prefab;

        [Tooltip("Count of cells in a row.")]
        [SerializeField] private int widthCount = 4;

        [Tooltip("Count of cells in a column.")]
        [SerializeField] private int heightCount = 4;

        [Tooltip("Distance between cells.")]
        [SerializeField] private float offset = 50;

        private void Start()
        {
            FillGrid();
        }

        public void FillGrid()
        {
            SetGridSettings();

            for (int i = 0; i < widthCount * heightCount; i++)
            {
                CreateGameObject();
            }
        }

        private void SetGridSettings()
        {
            gridLayoutGroup.cellSize = CalculateOptimalSizeOfCell();
            gridLayoutGroup.spacing = new Vector2(offset, offset);
        }

        private Vector2 CalculateOptimalSizeOfCell()
        {
            float gridWidth = rectTransform.sizeDelta.x;
            float gridHeight = rectTransform.sizeDelta.y;
            float cellWidth = (gridWidth - widthCount * offset) / widthCount;
            float cellHeight = (gridHeight - heightCount * offset) / heightCount;
            if (cellWidth <= 0 || cellHeight <= 0)
                throw new System.Exception("Wrong size of cell!");

            return new Vector2(cellWidth, cellHeight);
        }

        #region ICreatable implementation

        public ItemPlace CreateGameObject()
        {
            ItemPlace itemPlaceInstance = Instantiate<ItemPlace>(prefab, rectTransform.position, rectTransform.rotation, gridContainerAsParent);
            itemPlaceInstance.Parent = itemContainerAsParent;
            return itemPlaceInstance;
        }

        #endregion
    }
}
