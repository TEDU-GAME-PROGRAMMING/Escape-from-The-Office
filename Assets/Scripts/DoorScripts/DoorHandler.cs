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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpeningDoor();
        }
    }

    public void OpenKeyDoor(string KeyColor)
    {
        if (doorType == DoorType.Key)
        {
            if (KeyColor.Equals(DoorColor))
            {
                OpeningDoor();
            }
            //If player has a right key, open.
            
        }
    }
    public void OpenPasswordDoor()
    {
        if (doorType == DoorType.Password)
        {
            //If player found the password, open.
            OpeningDoor();
        }
      
    }
    public void BrokeDoor()
    {
        if (doorType == DoorType.Broke)
        {
            //If player has tool to broke, open.
        }
    }
    public void OpenLeverDoor()
    {
        if (doorType == DoorType.Lever)
        {
            //If player open a lever, open
            OpeningDoor();
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
