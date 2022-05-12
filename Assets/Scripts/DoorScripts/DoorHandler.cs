using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorHandler : MonoBehaviour
{
    [SerializeField]private DoorType doorType;
    public string DoorColor;

    public GameObject Door;
    public Transform Hinge;

    public bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
    }

    public string GetDoorType()
    {
        if (doorType == DoorType.Password)
        {
            return "Password";
        }
        if (doorType == DoorType.Key)
        {
            return "Key";
        }
        if (doorType == DoorType.Lever)
        {
            return "Lever";
        }
        if (doorType == DoorType.PressurPlate)
        {
            return "PressurPlate";
        }
        if (doorType == DoorType.Broke)
        {
            return "Broke";
        }

        return "ERROR";
    }
    public void BrokeDoor()
    {
        if (doorType == DoorType.Broke)
        {
            //If player has tool to broke, open.
        }
    }

    public void OpenPressurePlateDoor()
    {
        if (doorType == DoorType.PressurPlate)
        {

            //If player press the pressure plate, open.
            OpeningDoor();
        }
        
    }

    public void OpeningDoor()
    {
        
        Door.transform.RotateAround(Hinge.position,new Vector3(0,1,0),-90f);
        
        
    }

    public void ClosingDoor()
    {

        Door.transform.RotateAround(Hinge.position, new Vector3(0, 1, 0), 90f);


    }
    
}
