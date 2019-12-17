using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Episode1Intro.PromptWindow
{
    public class AgreeToStartGameMessageBoxController : MonoBehaviour
    {
        public void PressYes()
        {
            HideMessageBox();
            // Add some content
            SceneManager.LoadScene("Episode1");
        }

        public void PressNo()
        {
            HideMessageBox();
            // May be add some content
            SceneManager.LoadScene("MainMenu");
        }

        private void HideMessageBox()
        {
            gameObject.SetActive(false);
        }
    }
}