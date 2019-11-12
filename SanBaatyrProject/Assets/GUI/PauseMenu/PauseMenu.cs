using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUI.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        [SerializeField] 
        private GameObject pauseMenuPanel;

        [SerializeField]
        private GameObject pauseButton;

        private void PauseButton()
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseButton();
            }
        }

        public void Resume()
        {
            pauseMenuPanel.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuPanel.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void ToMainMenu()
        {
            Resume();
            SceneManager.LoadScene("MainMenu");
        }
    
        public void Quit()
        {
            Application.Quit();
        }
    }
}
