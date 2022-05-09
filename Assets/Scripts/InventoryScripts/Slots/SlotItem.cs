using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{

    public InventoryItem item;

    public void setitem(InventoryItem _item)
    {
        item = _item;
    }
}
