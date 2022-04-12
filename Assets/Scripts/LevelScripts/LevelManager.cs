using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform ParentLevelObject;
    public Level CurLevel;
    private Coroutine _coroutine;
    public readonly string LEVEL_SAVE_PATH = "Assets/Levels";
    #region Coroutine

    private IEnumerator LoadLevelCoroutine(Level level)
    {
        foreach (Transform child in ParentLevelObject.transform)
        {
            #if UNITY_EDITOR
            DestroyImmediate(child.gameObject);
            #endif
        }
        foreach (var levelObject in level.LevelObject.children)
        {
            CreateLevelObjects(levelObject);
        }

        CurLevel = level;
        yield return null;
        _coroutine = null;
    }

    private IEnumerator SaveLevelToFileCoroutine(string levelName)
    {
        string dir = $"{LEVEL_SAVE_PATH}/{levelName}/"; 
        string levelObjPath = $"{dir}{levelName}.asset"; 
        string levelObjectsPath = $"{dir}Level Objects/";
        string levelPrefabPath = $"{levelObjectsPath}Prefabs/";
        
        CreateDirectory(dir, levelObjectsPath, levelPrefabPath);
        
        string rootLevelObjectPath = $"{levelObjectsPath}/root.asset";
        LevelObject levelRootObject = ScriptableObject.CreateInstance<LevelObject>();
        levelRootObject.Prefab = ParentLevelObject.gameObject;
        levelRootObject.children = new List<LevelObject>();
        Debug.Log("ALO");
        foreach (Transform child in ParentLevelObject.transform)
        {
            SaveLevelToFile(ref levelRootObject, child.gameObject, ref levelObjectsPath);
        }
        
        AssetDatabase.CreateAsset(levelRootObject, rootLevelObjectPath);
        
        Level level = ScriptableObject.CreateInstance<Level>();
        level.Name = levelName;
        level.LevelObject = levelRootObject;
        AssetDatabase.CreateAsset(level, levelObjPath);
        
        yield return null;
        _coroutine = null;
    }
    
    #endregion

    #region Load Level
    
    public void LoadLevel(Level level)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(LoadLevelCoroutine(level));
        }
    }
    
    private void CreateLevelObjects(LevelObject levelObject)
    {
        GameObject _gameObject = Instantiate(levelObject.Prefab, ParentLevelObject.transform);
    }

    #endregion

    #region Save Level
    
    public void SaveLevel(string levelName)
    {
        Debug.Log(_coroutine);
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(SaveLevelToFileCoroutine(levelName));
        }
    }
    private void SaveLevelToFile(ref LevelObject levelObject, GameObject _gameObject, ref string levelObjectsPath)
    {
        string prefabPath = $"{levelObjectsPath}Prefabs/{_gameObject.name}.prefab";
        GameObject prefab = SavePrefab(_gameObject, prefabPath);
        LevelObject childLevelObject = ScriptableObject.CreateInstance<LevelObject>();
        childLevelObject.Prefab = prefab;
        levelObject.children.Add(childLevelObject);
        
        string levelObjectPath = $"{levelObjectsPath}{prefab.name}.asset";
        
        AssetDatabase.CreateAsset(childLevelObject, levelObjectPath);
    }
    private GameObject SavePrefab(GameObject _gameObject, string path)
    {
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(_gameObject, path);
        return prefab;
    }

    private void CreateDirectory(params string[] paths)
    {
        foreach (var path in paths)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    #endregion
}
