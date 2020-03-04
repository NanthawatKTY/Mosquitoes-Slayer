using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
   
    public bool SettingPaused = false;

    public GameObject settingMenuUI;


    // Update is called once per frame
    void Update()
    {

            if (SettingPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }


    }


    public void Resume()
    {
        settingMenuUI.SetActive(false);
        SettingPaused = false;
        Time.timeScale = 0f;

    }

    public void Pause()
    {
        settingMenuUI.SetActive(true);
        Time.timeScale = 0f;
        SettingPaused = true;
    }

  
  
}
