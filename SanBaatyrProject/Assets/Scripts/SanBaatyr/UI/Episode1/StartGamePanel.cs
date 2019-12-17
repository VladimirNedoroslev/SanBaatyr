using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGamePanel : MonoBehaviour
{
    public GameObject mainMenuPanel;


    public void GoToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void StartEpisode1()
    {
        SceneManager.LoadScene("Episode1");
    }

    public void StartEpisode2()
    {
        SceneManager.LoadScene("Episode2");
    }
}