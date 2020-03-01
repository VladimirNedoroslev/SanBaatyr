using Core.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SanBaatyr.UI.Episode1
{
    public class StartGamePanel : MonoBehaviour
    {
        public GameObject mainMenuPanel;
        public LoadingSceneController LoadingSceneController;


        public void GoToMainMenu()
        {
            mainMenuPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        public void StartEpisode1()
        {
            gameObject.SetActive(false);
            LoadingSceneController.LoadScene(SceneNames.VladimirTestScene);
        }

        public void StartEpisode2()
        {
            SceneManager.LoadScene("Episode2");
        }
    }
}