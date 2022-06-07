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
        [SerializeField] private int value;

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public void SaveValue()
        {
            PlayerPrefs.SetInt(name, Value);
        }

        public void LoadValue()
        {
            if (PlayerPrefs.HasKey(name))
            {
                Value = PlayerPrefs.GetInt(name);
            }
            else
            {
                PlayerPrefs.SetInt(name, 0);
            }
        }
    }
}