using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MASTER_SOUND_KEY = "SoundKey";
    private const string MASTER_MUSIC_KEY = "VolumeKey";
    private const string MASTER_GRAPHICS_KEY = "GraphicsKey";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const int MIN_GRAPHICS= 0;
    const int MAX_GRAPHICS = 2;
    const float DEFAULT_VOLUME = 0.2f;
    const int DEFAULT_GRAPHICS = 1;


    private const string MASTER_UNLOCKED_LEVEL_KEY = "UnlockedLevelKey";
    const int MIN_UNLOCKEDLEVEL = 0;
    const int MAX_UNLOCKEDLEVEL = 3;
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
    
    public static int getGraphics()
    {
        return PlayerPrefs.GetInt(MASTER_GRAPHICS_KEY);
    }
    public static void setGraphics(int graphics)
    {
        if(graphics >= MIN_GRAPHICS && graphics <= MAX_GRAPHICS)
        {
            PlayerPrefs.SetInt(MASTER_GRAPHICS_KEY, graphics);
        }
        else
        {
            Debug.LogError("MASTER GRAPH IS OUT OF RANGE");
        }
        
    }
    
    public static int getUnlockedLevel()
    {
        return PlayerPrefs.GetInt(MASTER_UNLOCKED_LEVEL_KEY);
    }
    public static void setUnlockedLevel(int unlockedLevel)
    {
        int lastUnlockedLevel = getUnlockedLevel();
        if(unlockedLevel >= MIN_UNLOCKEDLEVEL && unlockedLevel <= MAX_UNLOCKEDLEVEL && unlockedLevel > lastUnlockedLevel)
        {
            PlayerPrefs.SetInt(MASTER_UNLOCKED_LEVEL_KEY, unlockedLevel);
        }
        else
        {
            Debug.LogError("MASTER UNLOCKED LEVEL IS OUT OF RANGE");
        }
        
    }
    
    
    
    public static void setDefault()
    {
        PlayerPrefs.SetFloat(MASTER_SOUND_KEY, DEFAULT_VOLUME);
        PlayerPrefs.SetFloat(MASTER_MUSIC_KEY, DEFAULT_VOLUME);
        PlayerPrefs.SetInt(MASTER_GRAPHICS_KEY, DEFAULT_GRAPHICS);
        
    }

    public static float getDefaultVolume()
    {
        return DEFAULT_VOLUME;
    }

    public static int getDefaultGraphics()
    {
        return DEFAULT_GRAPHICS;
    }
}
