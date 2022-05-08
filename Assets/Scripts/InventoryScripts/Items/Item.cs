using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    //TODO: Item tipleri belirlenecek. 
    Key,
    Script,
    Object,
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType type;
    public Sprite icon;

    [TextArea(15,20)]
    public string description;    
}
