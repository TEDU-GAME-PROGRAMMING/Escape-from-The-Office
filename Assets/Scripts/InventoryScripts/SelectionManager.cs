using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    float maxDistance = 5f;

    public Inventory inventory;
    public TextMeshProUGUI interactTextMesh;


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            var selection = hit.transform;
            if(selection.GetComponent<InventoryItem>() != null)
            {
                InventoryItem inventoryItem = selection.GetComponent<InventoryItem>();
                
                interactTextMesh.enabled = true;
                interactTextMesh.text = $"Press [E] to pick up <color=\"red\"><b>{inventoryItem.item.itemName}</b></color>";
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventory.AddItem(inventoryItem);
                }
                    
            } 
            
        }
        else
        {
            interactTextMesh.enabled = false;
        }
    }
}
