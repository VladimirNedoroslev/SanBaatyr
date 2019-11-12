using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    
    public GameObject aboutUsPanel;
    public GameObject languagesPanel;
    public GameObject startGamePanel;

    public void ShowStartGamePanel()
    {
        startGamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void ShowAboutUsPanel()
    {
        aboutUsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowLanguagesPanel()
    {
        languagesPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
