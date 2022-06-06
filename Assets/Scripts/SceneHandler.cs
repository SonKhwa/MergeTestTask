using UnityEngine;
using UnityEngine.SceneManagement;

namespace miniit.MERGE
{
    public class SceneHandler : MonoBehaviour
    {
        public static void LoadScene(StringVariable sceneName) 
        {
            SceneManager.LoadSceneAsync(sceneName.Value);
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public static AsyncOperation GetLoadSceneAsync(StringVariable sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName.Value);
        }

        public static void EndGame()
        {
            Application.Quit();
        }
    }
}
