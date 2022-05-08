using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MAX_CAPACITY = 9;
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(InventoryItem item)
    {
        if (inventoryItems.Count < MAX_CAPACITY)
        {
            Collider collider = item.GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                inventoryItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}