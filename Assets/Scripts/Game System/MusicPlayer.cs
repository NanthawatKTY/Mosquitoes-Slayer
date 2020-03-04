using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMAsterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public static MusicPlayer instance;

    void Singleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (instance = this)
        {
            DontDestroyOnLoad(gameObject);
        }



 


        // Changing the song when loading a specific level
    }
}
