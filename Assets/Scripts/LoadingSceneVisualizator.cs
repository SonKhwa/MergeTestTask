using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    public class LoadingSceneVisualizator : MonoBehaviour
    {
        [SerializeField] private StringVariable nextScene;
        [SerializeField] private Image loadingProgressBar;
        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

        public void StartLoadingScreen()
        {
            scenesToLoad.Add(SceneHandler.GetLoadSceneAsync(nextScene));
            StartCoroutine(StartLoading());
        }

        private IEnumerator StartLoading()
        {
            float totalProgress = 0;
            for (int i = 0; i < scenesToLoad.Count; i++)
            {
                while (scenesToLoad[i].isDone == false)
                {
                    totalProgress += scenesToLoad[i].progress;
                    loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                    yield return null;
                }

            }
        }
    }
}
