using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    [CreateAssetMenu(fileName = "CombinationInfo", menuName = "My Scriptable Objects/CombinationInfo")]
    public class CombinationInfo : ScriptableObject
    {
        [Tooltip("Must be two parts for combination.")]
        [SerializeField] private StoringObjectInfo[] parts;

        [Tooltip("Combination color.")]
        [SerializeField] private StoringObjectInfo result;

        public StoringObjectInfo Result
        {
            get => result;
            set => result = value;
        }

        public bool Equals(StoringObjectInfo[] otherParts)
        {
            if (this.parts == null || this.result == null)
                throw new System.Exception(this.name + " is not implemented!");

            return this.parts[0] == otherParts[0] && this.parts[1] == otherParts[1]
                || this.parts[0] == otherParts[1] && this.parts[1] == otherParts[0];
        }
    }
}
