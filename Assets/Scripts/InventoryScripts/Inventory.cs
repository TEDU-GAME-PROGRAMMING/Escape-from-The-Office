using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public InventoryItem selectedItem;
    private const int MAX_CAPACITY = 9;
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<SlotItem> slotItems = new List<SlotItem>();    
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

    private void Update()
    {
        //get the input
        string input = Input.inputString;

        //ignore null input to avoid unnecessary computation
        if (!string.IsNullOrEmpty(input))
        {
            switch (input)
            {
                case "1":
                    if(inventoryItems.Count > 0)
                    {
                        selectedItem = inventoryItems[0];
                        Debug.Log("Selected item:" + selectedItem.item.itemName);
                        changeColorOfSelectedIndex(0);
                        
                    }
                    break;
                case "2":
                    if (inventoryItems.Count > 1)
                    {
                        selectedItem = inventoryItems[1];
                        changeColorOfSelectedIndex(1);

                    }
                    break;
                case "3":
                    if (inventoryItems.Count > 2)
                    {
                        selectedItem = inventoryItems[2];
                        changeColorOfSelectedIndex(2);

                    }
                    break;
                case "4":
                    if (inventoryItems.Count > 3)
                    {
                        selectedItem = inventoryItems[3];
                        changeColorOfSelectedIndex(3);
                    }
                    break;
                case "5":
                    if (inventoryItems.Count > 4)
                    {
                        selectedItem = inventoryItems[4];
                        changeColorOfSelectedIndex(4);
                    }
                    break;
                case "6":
                    if (inventoryItems.Count > 5)
                    {
                        selectedItem = inventoryItems[5];
                        changeColorOfSelectedIndex(5);
                    }
                    break;
                case "7":
                    if (inventoryItems.Count > 6)
                    {
                        selectedItem = inventoryItems[6];
                        changeColorOfSelectedIndex(6);
                    }
                    break;
                case "8":
                    if (inventoryItems.Count > 7)
                    {
                        selectedItem = inventoryItems[7];
                        changeColorOfSelectedIndex(7);
                    }
                    break;
                case "9":
                    if (inventoryItems.Count > 8)
                    {
                        selectedItem = inventoryItems[8];
                        changeColorOfSelectedIndex(8);
                    }
                    break;
            }
        
        }
    }

    private void changeColorOfSelectedIndex(int index)
    {
        int count = inventoryItems.Count;

        Debug.Log(inventoryItems.Count);
        for (int i = 0; i < count; i++)
        {
            if(i != index)
            {
                Debug.Log("BEYAZ");
                /*var colors = inventoryItems[i].GetComponentInParent<Button>().colors;
                colors.normalColor = Color.white;
                inventoryItems[i].GetComponentInParent<Button>().colors = colors;*/
                slotItems[i].transform.parent.transform.GetComponent<Image>().color = Color.white ;

                Debug.Log(slotItems[i].transform.parent.GetComponent<Image>().color);
            }
            else
            {
                Debug.Log("yesil");
                /*var colors = inventoryItems[i].GetComponentInParent<Button>().colors;
                colors.normalColor = Color.green;
                inventoryItems[i].GetComponentInParent<Button>().colors = colors;*/
                slotItems[i].transform.parent.transform.GetComponent<Image>().color = Color.green;
                Debug.Log(slotItems[i].transform.parent.GetComponent<Image>().color);
            }
        }
    }
}
