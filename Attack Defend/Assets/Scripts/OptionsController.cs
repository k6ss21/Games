using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    float defaultVolume = 0.1f;

    [SerializeField] Slider diffSlider;
    float defaultDifficulty = 3;

    MusicPlayer musicPlayer;

    private void Awake()
    {
        volumeSlider.value = 0.1f;
    }
    void Start()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
         diffSlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
            musicPlayer.SetVolume(volumeSlider.value);
            
    
       
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);

        PlayerPrefsController.SetDifficulty(diffSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
     
}
