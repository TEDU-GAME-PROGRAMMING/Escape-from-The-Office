using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPassParameter : MonoBehaviour
{
    [SerializeField] public Level SelectedLevel { get; set; }
  
    private static LevelSelectionPassParameter instance = null;
    void Awake()
    {
        LevelSelectionPassParameter[] passParametersObjs = FindObjectsOfType<LevelSelectionPassParameter>();
        
        if (passParametersObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
