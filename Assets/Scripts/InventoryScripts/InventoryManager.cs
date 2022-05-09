using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory Inventory;

    private void Start()
    {
        Inventory.ItemAdded += InventoryItemAdd;
    }

    private void InventoryItemAdd(object sender, InventoryEventArgs e)
    {
        
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.item.icon;
                slot.GetChild(0).GetChild(0).GetComponent<SlotItem>().setitem(e.Item);
                break;
            }
        }
    }
}
