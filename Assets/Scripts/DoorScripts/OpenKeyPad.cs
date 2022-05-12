using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject KeyPad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            OpenKeyPadHandler();
        }
    }
    public void OpenKeyPadHandler()
    {
        CharacterMovements charMovements = FindObjectOfType<CharacterMovements>();
        charMovements.isPlayerEnable = false;
        KeyPad.SetActive(true);
    }

    public void CloseKeyPad()
    {
        CharacterMovements charMovements = FindObjectOfType<CharacterMovements>();
        charMovements.isPlayerEnable = true;
        KeyPad.SetActive(false);
    }
}
