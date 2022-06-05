using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public abstract class ColoringStoringObject : StoringObject, IColorableByStoringObjectInfo
    {
        [SerializeField] protected Image image;

        public override StoringObjectInfo StoringObjectInfo
        {
            get => storingObjectInfo;
            set
            {
                storingObjectInfo = value;
                ColorImage();
            }
        }

        private void Start()
        {
            ColorImage();
        }

        #region IColorableByStoringObjectInfo implementation

        public virtual void ColorImage()
        {
            image.color = StoringObjectInfo.Color;
        }

        #endregion
    }
}