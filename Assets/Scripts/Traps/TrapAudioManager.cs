using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefsManager.getSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(int indexOfType)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[indexOfType]);
    }
}
