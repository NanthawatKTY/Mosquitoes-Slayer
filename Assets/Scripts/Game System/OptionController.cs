using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;


    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMAsterVolume();

    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else 
        {
            Debug.LogWarning("No music volume");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
