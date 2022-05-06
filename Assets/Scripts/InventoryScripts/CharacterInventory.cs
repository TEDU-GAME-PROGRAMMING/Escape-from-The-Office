using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{   
    public Inventory inventory;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.GetComponent<InventoryItem>() != null)
        {
            InventoryItem inventoryItem = collision.collider.GetComponent<InventoryItem>();
            
            Debug.Log("Bu bir '" + inventoryItem.item.itemName + "' nesnesidir.");

            if (inventoryItem != null)
            {
                inventory.AddItem(inventoryItem);
            }
        }
       
    }
}
