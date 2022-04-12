using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{
    
    private string levelName = "Level 1";
        
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Editor Scripts", EditorStyles.boldLabel);

        levelName = EditorGUILayout.TextField("Level Name", levelName);

        if (GUILayout.Button("Save Level"))
        {
            Debug.Log(levelName);
            FindObjectOfType<LevelManager>().SaveLevel(levelName);
        }

        if (GUILayout.Button("Load Level"))
        {
            string path = EditorUtility.OpenFilePanel("Select asset", FindObjectOfType<LevelManager>().LEVEL_SAVE_PATH, "asset");
            if (path.Length != 0)
            {
                string newPath = path.Split(new string[] { "warsky/" }, StringSplitOptions.None)[1];
                Level level = AssetDatabase.LoadAssetAtPath<Level>(newPath);

                if (level != null)
                {
                    FindObjectOfType<LevelManager>().LoadLevel(level);
                }
            }
        }

    }
}
