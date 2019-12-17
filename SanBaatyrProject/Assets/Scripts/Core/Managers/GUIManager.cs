using UnityEngine;

namespace Prefabs.MetaObjects.GUIManager
{
    public class GUIManager : Singleton<GUIManager>
    {
        public GameObject gameOverPanel;

        public void ShowGameOverScreen()
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<Animator>().SetBool("Start", true);
            Time.timeScale = 1f;
        }
    }
}