using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.UI
{
    public class LoadingSceneController : MonoBehaviour
    {
        public GameObject LoadingScreenUi;
        public Slider slider;
        public GameObject startEpisodeButton;

        private AsyncOperation _asyncOperation;

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadingScreen(sceneName));
        }

        public void StartScene()
        {
            _asyncOperation.allowSceneActivation = true;
        }

        private IEnumerator LoadingScreen(string sceneName)
        {
            LoadingScreenUi.SetActive(true);
            _asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            _asyncOperation.allowSceneActivation = false;

            while (_asyncOperation.isDone == false)
            {
                slider.value = _asyncOperation.progress;
                if (_asyncOperation.progress == 0.9f)
                {
                    slider.value = 1f;
                    startEpisodeButton.SetActive(true);
                }

                yield return null;
            }
        }
    }
}