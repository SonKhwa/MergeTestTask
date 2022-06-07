using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public abstract class ConvertablePlace<T> : Place, IConvertable, ICreatable<T> where T : StoringObject
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

            T storingObjectInstance = CreateGameObject();
            storingObjectInstance.StoringObjectInfo = StoringObject.StoringObjectInfo;

            Destroy(StoringObject.gameObject);
            StoringObject = storingObjectInstance;
        }

        #endregion

        #region ICreatable implementation

        public T CreateGameObject()
        {
            T storingObjectInstance = Instantiate<T>(pathToPrefab, rectTransform.position, rectTransform.rotation, parent);
            StoringObject.Place = this;
            return storingObjectInstance;
        }

        #endregion
    }
}