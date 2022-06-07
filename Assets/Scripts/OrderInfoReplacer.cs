using Doozy.Runtime.Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class OrderInfoReplacer : MonoBehaviour
    {
        [Tooltip("StreamCategory of signals.")]
        [SerializeField] private string LevelEvents = nameof(LevelEvents);

        [Tooltip("StreamCategory of signal OnProductWrong")]
        [SerializeField] private string OnProductWrong = nameof(OnProductWrong);

        [Tooltip("StreamCategory of signal OnProductCorrect")]
        [SerializeField] private string OnProductCorrect = nameof(OnProductCorrect);

        [SerializeField] private Image orderImage;
        [SerializeField] private TextMeshProUGUI orderName;
        [SerializeField] private IntVariable scores;

        private void Start()
        {
            scores.Value = 0;
        }

        public void SetOrder(StoringObjectInfo objectInfo)
        {
            orderImage.sprite = objectInfo.ProductImage;
            orderImage.color = objectInfo.Color;
            orderName.text = objectInfo.ProductName;
        }

        public void ReactOnCorrectProduct(StoringObjectInfo objectInfo)
        {
            Debug.Log("Correct product!");
            scores.Value += objectInfo.Level;
            SignalStream.Get(LevelEvents, OnProductCorrect).SendSignal();
        }

        public void ReactOnWrongProduct(StoringObjectInfo objectInfo)
        {
            Debug.Log("Wrong product!");
            scores.Value -= objectInfo.Level;
            SignalStream.Get(LevelEvents, OnProductWrong).SendSignal();
        }
    }
}