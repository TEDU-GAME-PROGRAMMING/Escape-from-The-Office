using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    float maxDistance = 0.9f;

    public Inventory inventory;
    public GameObject interact;
    public TextMeshProUGUI interactTextMesh;
    public GameObject keyboardButtonParent;
    public TextMeshProUGUI keyboardButtonName;
    public Image keyboardButtonProgress;
    public float interactDuration;
    public float collectDuration;

    private float currentTimeElapsed;
    private bool isFinished = false;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
            var selection = hit.transform;
            if (selection.GetComponent<InventoryItem>() != null)
            {
                InventoryItem inventoryItem = selection.GetComponent<InventoryItem>();
                if (inventoryItem.item.type == ItemType.Object)
                {
                    interact.SetActive(true);
                    keyboardButtonParent.SetActive(true);
                    interactTextMesh.text = $"Hold down [E] to pick up <color=\"red\"><b>{inventoryItem.item.itemName}</b></color>";
                    keyboardButtonName.text = "E";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        IncrementProgress(collectDuration);
                        if (isFinished)
                        {
                            inventory.AddItem(inventoryItem);
                            isFinished = false;
                        }
                    }
                    else
                    {
                        currentTimeElapsed = 0f;
                    }
                    updateProgressImage(collectDuration);
                }

                if (inventoryItem.item.type == ItemType.Script)
                {
                   
                    interact.SetActive(true);
                    keyboardButtonParent.SetActive(false);
                    interactTextMesh.text = $"<b>{inventoryItem.item.description}</b>";
                   
                }
               
            }

            if (selection.GetComponent<Lever>() != null)
            {
                Lever lever = selection.GetComponent<Lever>();
                interact.SetActive(true);
                keyboardButtonParent.SetActive(true);
                if (lever.isActive)
                {
                    interactTextMesh.text = "Hold down [E] to <color=\"red\"><b>disable</b></color> lever";
                }
                else
                {
                    interactTextMesh.text = "Hold down [E] to <color=\"red\"><b>enable</b></color> lever";
                }
                keyboardButtonName.text = "E";

                if (Input.GetKey(KeyCode.E))
                {
                    IncrementProgress(interactDuration);
                    if (isFinished)
                    {
                        lever.isActive = !lever.isActive;
                        isFinished = false;
                    }
                }
                else
                {
                    currentTimeElapsed = 0f;
                }
                updateProgressImage(interactDuration);
            }

            if (selection.GetComponent<DoorHandler>() && !selection.GetComponent<DoorHandler>().isOpened)
            {
                GameObject DoorObject = selection.gameObject;
                if (DoorObject.GetComponent<DoorHandler>().GetDoorType().Equals("Password"))
                {
                    GameObject parentDoorSystem = selection.transform.parent.gameObject;
                    interact.SetActive(true);
                    keyboardButtonParent.SetActive(true);
                    interactTextMesh.text = "Hold down [E] to <color=\"red\"><b>open password keypad</b></color>";
                    keyboardButtonName.text = "E";

                    if (Input.GetKey(KeyCode.E))
                    {
                        IncrementProgress(interactDuration);
                        if (isFinished)
                        {
                            Cursor.lockState = CursorLockMode.None;
                            parentDoorSystem.GetComponent<PasswordDoorSystemHandler>().KeypadCanvas.gameObject.SetActive(true);
                            isFinished = false;
                            FindObjectOfType<CharacterMovements>().isPlayerEnable = false;
                        }
                    }
                    else if (Input.GetKey(KeyCode.R))
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        parentDoorSystem.GetComponent<PasswordDoorSystemHandler>().KeypadCanvas.gameObject.SetActive(false);
                        FindObjectOfType<CharacterMovements>().isPlayerEnable = true;
                    }
                    else
                    {
                        currentTimeElapsed = 0f;
                    }
                    updateProgressImage(interactDuration);
                }
                
            }

        }
        else
        {
            interact.SetActive(false);
        }
    }

    private void updateProgressImage(float duration)
    {
        float ppd = currentTimeElapsed / duration;
        keyboardButtonProgress.fillAmount = ppd;
    }

    private void IncrementProgress(float duration)
    {
        currentTimeElapsed += Time.deltaTime;
        if (currentTimeElapsed >= duration)
        {
            isFinished = true;
            currentTimeElapsed = 0f;
        }
    }
}
