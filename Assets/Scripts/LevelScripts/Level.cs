using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ScriptableObject
{
    public string Name;
    public string Description;
    public float TimeToPass;
    public LevelObject LevelObject;
}
