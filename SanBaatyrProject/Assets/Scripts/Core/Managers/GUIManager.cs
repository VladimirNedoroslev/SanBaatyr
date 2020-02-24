using UnityEngine;

namespace Core.Managers
{
    public class GUIManager : Singleton<GUIManager>
    {
        public GameObject gameOverPanel;

        public void ShowGameOverScreen()
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Player is dead");
            gameOverPanel.GetComponent<Animator>().SetBool("Start", true);
            Time.timeScale = 1f;
        }
    }
}