using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MASTER_SOUND_KEY = "SoundKey";
    private const string MASTER_MUSIC_KEY = "VolumeKey";
    private const string MASTER_SENSIVITY_KEY = "SensKey";
    
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_SENS = 1f;
    const float MAX_SENS = 5f;

    const float DEFAULT_VOLUME = 0.2f;

    const float DEFAULT_SENS = 3f;

    private const string MASTER_UNLOCKED_LEVEL_KEY = "UnlockedLevelKey";
    const int MIN_UNLOCKEDLEVEL = 0;
    const int MAX_UNLOCKEDLEVEL = 2;
    const int DEFAULT_UNLOCKEDLEVEL = 1;
    public static float getSound()
    {
        return PlayerPrefs.GetFloat(MASTER_SOUND_KEY);
    }
    public static void setSound(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_SOUND_KEY, volume);
        }
        else
        {
            Debug.LogError("MASTER VOLUME IS OUT OF RANGE");
        }
        
    }
    
    public static float getMusic()
    {
        return PlayerPrefs.GetFloat(MASTER_MUSIC_KEY);
    }
    public static void setMusic(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_MUSIC_KEY, volume);
            
        }
        else
        {
            Debug.LogError("MASTER VOLUME IS OUT OF RANGE");
        }
        
    }

    public static float getSens()
    {
        return PlayerPrefs.GetFloat(MASTER_SENSIVITY_KEY);
    }

    public static void setSens(float sens)
    {
        if(sens >= MIN_SENS && sens <= MAX_SENS)
        {
            PlayerPrefs.SetFloat(MASTER_SENSIVITY_KEY, sens);
        }
        else
        {
            Debug.LogError("MASTER VOLUME IS OUT OF RANGE");
        }
        PlayerPrefs.SetFloat(MASTER_SENSIVITY_KEY, sens);
    }

    
    public static int getUnlockedLevel()
    {
        return PlayerPrefs.GetInt(MASTER_UNLOCKED_LEVEL_KEY);
    }
    public static void setUnlockedLevel(int unlockedLevel)
    {
        int lastUnlockedLevel = getUnlockedLevel();
        Debug.Log(lastUnlockedLevel);
        Debug.Log(unlockedLevel);
        if(unlockedLevel >= MIN_UNLOCKEDLEVEL && unlockedLevel <= MAX_UNLOCKEDLEVEL && unlockedLevel > lastUnlockedLevel)
        {
            PlayerPrefs.SetInt(MASTER_UNLOCKED_LEVEL_KEY, unlockedLevel);
           
        }
        else
        {
            Debug.LogError("MASTER UNLOCKED LEVEL IS OUT OF RANGE OR THIS LEVEL HAS ALREADY UNLOCKED");
        }
        
    }
    
    
    public static void setDefault()
    {
        PlayerPrefs.SetFloat(MASTER_SOUND_KEY, DEFAULT_VOLUME);
        PlayerPrefs.SetFloat(MASTER_MUSIC_KEY, DEFAULT_VOLUME);
        PlayerPrefs.SetFloat(MASTER_SENSIVITY_KEY, DEFAULT_SENS);
        
    }

 

    
}
