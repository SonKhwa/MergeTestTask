using UnityEngine;
using TMPro;

namespace miniit.MERGE
{
    public class TimeMonitor : MonoBehaviour
    {
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