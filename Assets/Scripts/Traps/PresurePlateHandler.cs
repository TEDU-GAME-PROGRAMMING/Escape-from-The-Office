using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlateHandler : MonoBehaviour
{
    bool IsOpen = false;

    public GameObject door;
    private DoorHandler doorHandler;

    int time = 5; //In Second

    private Vector3 replace = new Vector3(.0f, .01f, .0f);
    private bool IsCoroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        doorHandler = door.GetComponent<DoorHandler>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            transform.position -= replace;

            if (IsOpen == false)
            {
                doorHandler.OpeningDoor();
                IsOpen = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position += replace;

            //Wait For An Amount of time and Close the Door
            if (IsCoroutineStarted == false)
            {
                IsCoroutineStarted = true;
                StartCoroutine(WaitForClose());
            }
            else //Player Passes Plate Again
            {
                StopAllCoroutines();
                StartCoroutine(WaitForClose());

            }



        }

        IEnumerator WaitForClose()
        {

            //yield on a new YieldInstruction that waits for 5 seconds.         
            yield return new WaitForSeconds(time);


            if (IsOpen)
            {
                doorHandler.ClosingDoor();

                IsOpen = false;
                IsCoroutineStarted = false;
            }

        }
    }

}
