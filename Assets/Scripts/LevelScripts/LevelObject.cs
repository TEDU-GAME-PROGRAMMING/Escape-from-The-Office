using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : ScriptableObject
{
    public GameObject Prefab;
    public List<LevelObject> children;
}
