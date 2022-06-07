using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class ValueMonitor : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private IntVariable variable;
        [SerializeField] private bool isAlwaysUpdate = true;
        private int previousValue = 0;

        private void Start()
        {
            previousValue = variable.Value;
            UpdateText();
        }

        private void Update()
        {
            if (isAlwaysUpdate is true && previousValue != variable.Value)
            {
                UpdateText();
            }
        }

        public void UpdateText()
        {
            text.text = variable.Value.ToString();
        }
    }
}