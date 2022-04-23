using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PausePanel;

    public TextMeshProUGUI time;

    public LevelManager levelManager;

    public Level curLevel;

    public float timeToPass;
    // Start is called before the first frame update
    void Start()
    {
        curLevel = levelManager.CurLevel;
        timeToPass = curLevel.TimeToPass;

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
        
        //TODO IF TIME IS OVER EXPLODE BOMBS AND FINISH GAME
    }
    public void HandleLose(int loseType)
    {
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
}
