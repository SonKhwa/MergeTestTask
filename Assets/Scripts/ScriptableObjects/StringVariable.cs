using UnityEngine;

namespace miniit.MERGE
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "My Scriptable Objects/StringVariable")]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR

        [Multiline]
        public string DeveloperDescription = "";

#endif
        [SerializeField] private string value;

        public string Value
        {
            get => value;
            set => this.value = value;
        }
    }
}