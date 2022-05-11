using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private TrapType trapType;
    [SerializeField] private GameObject audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>().gameObject;
    }

    public bool CheckType()
    {
        return trapType == TrapType.Scissors || trapType == TrapType.Laser;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO death game over
            Debug.Log("You are death.");
            other.GetComponent<Character>().Death();
            audioSource.GetComponent<TrapAudioManager>().PlayEffect((int)trapType);//0:BOMB 1:BLADE 2:SPIKE 3:LASER
            WaitForSound();
            FindObjectOfType<LevelSceneManager>().HandleLose(0);
            
        }
        if(trapType == TrapType.Plane)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(2);
    }

    public void TimeFinished()
    {
        audioSource.GetComponent<TrapAudioManager>().PlayEffect(0);//BOMB SOUND
        WaitForSound();
        FindObjectOfType<LevelSceneManager>().HandleLose(1);
    }


}
