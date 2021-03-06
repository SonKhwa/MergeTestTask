using UnityEngine;
using TMPro;
using Doozy.Runtime.Signals;

namespace miniit.MERGE
{
    public class TimeMonitor : MonoBehaviour
    {
        [Tooltip("StreamCategory of signal OnLevelLost.")]
        [SerializeField] private string LevelEvents = nameof(LevelEvents);

        [Tooltip("StreamCategory of signal OnLevelLost.")]
        [SerializeField] private string OnLevelLost = nameof(OnLevelLost);

        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private float timeRemaining = 60f;
        private bool timerIsRunning = true;

        private void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    
                    Debug.Log("Time has run out! Game Over!");
                    SignalStream.Get(LevelEvents, OnLevelLost).SendSignal();
                    timeRemaining = 0;
                    timerIsRunning = false;
                }

            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void SetPause()
        {
            timerIsRunning = false;
        }

        public void SetUnpause()
        {
            timerIsRunning = true;
        }
    }
}