using UnityEngine;

namespace miniit.MERGE
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "My Scriptable Objects/IntVariable")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR

        [Multiline]
        public string DeveloperDescription = "";

#endif
        [SerializeField] int value;

        public int Value
        {
            get => value;
            set => this.value = value;
        }
    }
}