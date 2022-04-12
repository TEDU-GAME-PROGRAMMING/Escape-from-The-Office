using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneHandler : MonoBehaviour
{
    public Level curLevel;
    // Start is called before the first frame update
    void Start()
    {
        curLevel = FindObjectOfType<LevelSelectionPassParameter>().SelectedLevel;
        FindObjectOfType<LevelManager>().LoadLevel(curLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
