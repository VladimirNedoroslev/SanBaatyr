using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutUsPanel : MonoBehaviour
{

    public GameObject mainMenuPanel;

    public void GoToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
