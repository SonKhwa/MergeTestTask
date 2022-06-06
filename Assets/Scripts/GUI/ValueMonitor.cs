using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ValueMonitor : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private IntVariable variable;
        private int previousValue = 0;

        private void Start()
        {
            previousValue = variable.Value;
            UpdateText();
        }

        private void Update()
        {
            if (previousValue != variable.Value)
            {
                UpdateText();
            }
        }

        private void UpdateText()
        {
            text.text = variable.Value.ToString();
        }
    }
}