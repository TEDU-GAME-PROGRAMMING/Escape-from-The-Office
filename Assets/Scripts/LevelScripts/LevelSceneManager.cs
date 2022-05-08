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
    public bool levelFailed = false;
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
        if (!levelFailed)
        {
            TimeHandle();
        }
        
    }

    public void TimeHandle()
    {
        timeToPass -= Time.deltaTime;
        time.text = (int)(timeToPass / 60) + ":" + (int)(timeToPass % 60);
        if (timeToPass <= 0)
        {
            levelFailed = true;
            FindObjectOfType<TrapAudioManager>().PlayEffect(0);//0:BOMB 1:BLADE 2:SPIKE 3:LASER
            WaitForSound();
            HandleLose(0);
        }
        
       
    }
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(2);
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
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        SceneManager.LoadScene("GameplayScene");
    }
}
