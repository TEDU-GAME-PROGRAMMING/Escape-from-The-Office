using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> musics;
    public AudioSource audioSource;
    public bool playlistStarted = false;
    public int index = 0;
    private static MusicManager instance = null;
    void Awake()
    {
        audioSource.volume = PlayerPrefsManager.getMusic();
        MusicManager[] passParametersObjs = FindObjectsOfType<MusicManager>();
        audioSource.loop = false;
        if (passParametersObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update()
    {
        audioSource.volume = PlayerPrefsManager.getMusic();

        if (!audioSource.isPlaying)
        {
            audioSource.clip = musics[index];
            audioSource.Play();
            Debug.Log(musics[index].name +" "+ musics[index].length);
            Debug.Log(musics[index].length);
            index++;
            if (index >= musics.Count)
            {
                index = 0;
            }


        }
           

           

        
       
    }

    IEnumerator waitForMusic(int i)
    {
        
        yield return new WaitForSeconds(musics[i].length);
        Debug.Log("SARKI BITTI");
    }
}
