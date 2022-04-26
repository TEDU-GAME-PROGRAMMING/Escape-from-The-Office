using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PausePanel;
    public GameObject PauseButton;
    public TextMeshProUGUI time;

    public LevelManager levelManager;

    public Level curLevel;

    public float timeToPass;
    public List<Level> Levels;
    
    // Start is called before the first frame update
    void Start()
    {
        curLevel = FindObjectOfType<LevelSelectionPassParameter>().SelectedLevel;
        
        timeToPass = curLevel.TimeToPass;
        
        Debug.Log(curLevel.name + " " + curLevel.TimeToPass);
        time.text = (int)(timeToPass / 60) + ":" + (int)(timeToPass % 60);
    }

    // Update is called once per frame
    void Update()
    {
        TimeHandle();
    }

    public void TimeHandle()
    {
        timeToPass -= Time.deltaTime;
        time.text = (int)(timeToPass / 60) + ":" + (int)(timeToPass % 60);
        if (timeToPass <= 0)
        {
            //TODO IF TIME IS OVER EXPLODE BOMBS AND FINISH GAME
        }
        
       
    }
    public void HandleLose(int loseType)
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        if (loseType == 0)
        {
            //TODO Lose because of traps
        }
        else if (loseType == 1)
        {
            //TODO time has ended and bombs are exploded
        }
        LosePanel.SetActive(true);
    }
    public void HandleWin()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        int unlockedLevel = curLevel.ID + 1;
        PlayerPrefsManager.setUnlockedLevel(unlockedLevel);
        WinPanel.SetActive(true);
    }

    public void PauseHandle()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        
    }

    public void UnPauseHandle()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void LoadSettings()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SettingsScene");
    }
    public void LoadLevelSelectionScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelectionScene");
    }
    public void LoadNextLevel()
    {
        if (curLevel.ID + 1 < Levels.Count)
        {
            FindObjectOfType<LevelSelectionPassParameter>().SelectedLevel = Levels[curLevel.ID+1];
            SceneManager.LoadScene("GameplayScene");
        }
        else
        {
            SceneManager.LoadScene("EndGameScene");
        }
       

       
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
