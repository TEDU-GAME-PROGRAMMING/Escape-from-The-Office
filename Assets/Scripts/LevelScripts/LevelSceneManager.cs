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
    public bool levelFinished = false;
    public float timeToPass;
    public List<Level> Levels;

    public bool pauseOpen = false;
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

        if (Input.GetKeyDown(KeyCode.P) && !pauseOpen)
        {
            PauseHandle();
            pauseOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && pauseOpen)
        {
            UnPauseHandle();
            pauseOpen = false;
        }
        
    }

    public void TimeHandle()
    {
        timeToPass -= Time.deltaTime;
        time.text = (int)(timeToPass / 60) + ":" + (int)(timeToPass % 60);
        if (timeToPass <= 0)
        {
            levelFailed = true;
            FindObjectOfType<TrapAudioManager>().PlayEffect(4);//0:PAPER 1:BLADE 2:SPIKE 3:LASER
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
        Cursor.lockState = CursorLockMode.None;
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
   
    public void HandleWin(bool isLastFloor)
    {
        if (!levelFinished )
        {
            if (!isLastFloor)
            {
                levelFinished = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                PauseButton.SetActive(false);
                int unlockedLevel = curLevel.ID + 1;
                Debug.Log(curLevel.name + " " + curLevel.ID);
                PlayerPrefsManager.setUnlockedLevel(unlockedLevel);
                WinPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("EndGameScene");
            }
            
        }
        
    }

    public void PauseHandle()
    {
        
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        PausePanel.SetActive(true);
        
    }

    public void UnPauseHandle()
    {
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void LoadSettings()
    {
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("SettingsScene");
    }
    public void LoadLevelSelectionScene()
    {
       
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LevelSelectionScene");
    }
    public void LoadNextLevel()
    {
       
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
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
