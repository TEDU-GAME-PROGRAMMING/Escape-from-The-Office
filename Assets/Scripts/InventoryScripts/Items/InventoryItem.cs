using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryItem : MonoBehaviour
{
    public Item item;

    public void OnPickup()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(InventoryItem item)
    {
        Item = item;
    }
    public InventoryItem Item;
}



