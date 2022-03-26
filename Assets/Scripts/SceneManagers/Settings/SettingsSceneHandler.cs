using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsSceneHandler : MonoBehaviour
{
    
    

    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private TMP_Dropdown _graphicsDropdown;
    // Start is called before the first frame update
    void Start()
    {
        _soundSlider.value = PlayerPrefsManager.getSound();
        _musicSlider.value = PlayerPrefsManager.getMusic();
        _graphicsDropdown.value = PlayerPrefsManager.getGraphics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO music volume can be changed dynamically
    
    
    public void SavePlayerSettings()
    {
        PlayerPrefsManager.setSound(_soundSlider.value);
        PlayerPrefsManager.setMusic(_musicSlider.value);
        PlayerPrefsManager.setGraphics(_graphicsDropdown.value);
    }
    public void RestoreSettingsToDefault()
    {
        PlayerPrefsManager.setDefault();
        _musicSlider.value = PlayerPrefsManager.getDefaultVolume();
        _soundSlider.value = PlayerPrefsManager.getDefaultVolume();
        _graphicsDropdown.value = PlayerPrefsManager.getDefaultGraphics();
    }
}
