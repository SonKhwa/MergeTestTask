using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public abstract class ConvertablePlace<T> : Place, IConvertable, ICreatable where T : StoringObject
    {
        [SerializeField] private T pathToPrefab;
        [SerializeField] private Transform parent = null;

        public Transform Parent
        {
            get => parent;
            set => parent = value;
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
                }
            }
        }

        #region IConvertable implementation

        public void ConvertObject()
        {
            if (StoringObject is null)
            {
                throw new Exception("Convert wasn't stopped!");
            }

            StoringObjectInfo generalStoringObjectInfo = StoringObject.StoringObjectInfo;
            DestroyImmediate(StoringObject.gameObject);

            CreateGameObject();
            StoringObject.StoringObjectInfo = generalStoringObjectInfo;
            StoringObject = storingObject;
        }

        #endregion

        #region ICreatable implementation

        public void CreateGameObject()
        {
            T storingObjectInstance = Instantiate<T>(pathToPrefab, rectTransform.position, rectTransform.rotation, parent);
 
            storingObject = storingObjectInstance;
            StoringObject.Place = this;
        }

        #endregion
    }
}