using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class SceneHandler : MonoBehaviour
    {
        public float delayTime = 5f;
        [SerializeField] private string nextSceneName;
        [SerializeField] private Image loadingProgressBar;
        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

        public void StartLoadingScreen()
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync(nextSceneName));
            StartCoroutine(StartLoading());
        }

        private IEnumerator StartLoading()
        {
            float totalProgress = 0;
            for (int i = 0; i < scenesToLoad.Count; i++)
            {
                yield return new WaitForSeconds(delayTime);
                while (scenesToLoad[i].isDone == false)
                {
                    totalProgress += scenesToLoad[i].progress;
                    loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                    //yield return null;
                    yield return new WaitForSeconds(delayTime);
                }

            }
        }

        public void EndGame()
        {
            Application.Quit();
        }
    }
}
