using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    void Awake()
    {
        if (!PlayerPrefs.HasKey("SoundKey") || !PlayerPrefs.HasKey("VolumeKey") || !PlayerPrefs.HasKey("SensKey"))
        {
            PlayerPrefsManager.setDefault();
        }

        if (!PlayerPrefs.HasKey("UnlockedLevelKey"))
        {
            PlayerPrefs.SetInt("UnlockedLevelKey",0);
        }
    }
    
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void LoadLevelSelectionScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }

    public void OpenInfoPanel(GameObject InfoPanel)
    {
        InfoPanel.SetActive(true);
    }

    public void CloseInfoPanel(GameObject InfoPanel)
    {
        InfoPanel.SetActive(false);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
