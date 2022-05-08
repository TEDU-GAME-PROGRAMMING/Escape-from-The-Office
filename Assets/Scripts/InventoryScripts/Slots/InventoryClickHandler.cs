using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClickHandler : MonoBehaviour
{
    InventoryItem selectedItem = null;
    public void OnClicked()
    {
        if (gameObject.GetComponentInChildren<SlotItem>().item != null)
        {
            selectedItem = gameObject.GetComponentInChildren<SlotItem>().item;
            Debug.Log("You selected: " + selectedItem.item.itemName);
        } 
        else
        {
            Debug.Log("You selected an empty slot");
        }
    }
}
