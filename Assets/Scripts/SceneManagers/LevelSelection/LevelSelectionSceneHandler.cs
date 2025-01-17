using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionSceneHandler : MonoBehaviour
{
    public List<GameObject> LevelButtons;

    public List<Level> Levels;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (i <= PlayerPrefsManager.getUnlockedLevel())
            {
                LevelButtons[i].GetComponent<Button>().interactable = true;
                LevelButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                LevelButtons[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                LevelButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                LevelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                LevelButtons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSelectedLevelScene(int selectedLevel)
    {
        FindObjectOfType<LevelSelectionPassParameter>().SelectedLevel = Levels[selectedLevel];
     
        
        
        SceneManager.LoadScene("GameplayScene");
    }
}
