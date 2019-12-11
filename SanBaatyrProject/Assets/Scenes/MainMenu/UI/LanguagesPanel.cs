using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguagesPanel : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ChooseRussianLanguage()
    {
        //TODO: Change localization to Russian
        throw new NotImplementedException();
    }
    
    public void ChooseEnglishLanguage()
    {
        //TODO: Change localization to English
        throw new NotImplementedException();
    }
    
    public void ChooseKyrgyzLanguage()
    {
        //TODO: Change localization to Kyrgyz
        throw new NotImplementedException();
    }
}