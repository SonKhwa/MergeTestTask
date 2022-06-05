using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class GridFiller : MonoBehaviour, ICreatable
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private RectTransform gridContainer;
        [SerializeField] private GameObject prefab;

        [Tooltip("Count of cells in a row.")]
        [SerializeField] private int widthCount = 4;

        [Tooltip("Count of cells in a column.")]
        [SerializeField] private int heightCount = 4;

        [Tooltip("Distance between cells.")]
        [SerializeField] private float offset = 50;

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

        public void CreateGameObject()
        {
            GameObject itemPlaceInstance = Instantiate(prefab, rectTransform.position, rectTransform.rotation, gridContainer);
        }

        #endregion
    }
}
