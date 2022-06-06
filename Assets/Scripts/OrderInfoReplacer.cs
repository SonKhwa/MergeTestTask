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

        public void SetOrder(StoringObjectInfo objectInfo)
        {
            orderImage.sprite = objectInfo.ProductImage;
            orderImage.sprite = objectInfo.ProductImage;
            orderName.text = objectInfo.ProductName;
        }

        public void ReactOnCorrectProduct()
        {
            Debug.Log("Correct product!");
            SignalStream.Get(LevelEvents, OnProductCorrect).SendSignal();
        }

        public void ReactOnWrongProduct()
        {
            Debug.Log("Wrong product!");
            SignalStream.Get(LevelEvents, OnProductWrong).SendSignal();
        }
    }
}