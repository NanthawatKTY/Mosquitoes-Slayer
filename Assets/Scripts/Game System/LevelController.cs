﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfMosquito = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
       if (winLabel == null || loseLabel == null) { return; }

        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }


 
    public void AttackerSpawned()
    {
        numberOfMosquito++; //Increase mosquitoes : numberOfMosquito = numberOfMosquito + 1
    }

    public void AttackerKilled()
    {
        numberOfMosquito--; //Decrease mosquitoes : numberOfMosquito = numberOfMosquito - 1

        if (numberOfMosquito <= 0 && levelTimerFinished) 
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {

        if (numberOfMosquito <= 0 && levelTimerFinished == true)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad); //show win label 4 secs after that will resume next frame
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    public void HandleLoseCondition()
    {

        //  levelTimerFinished = true;
        SFXManagement.PlaySound("SpinningWheel");
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        SpawnerAttacker[] spawnerArray = FindObjectsOfType<SpawnerAttacker>(); //Keep spawnerArray values into spawner 
        foreach (SpawnerAttacker spawner in spawnerArray)
        {
            spawner.StopSpawning();  //Go to StopSpawning in SpawnerAttacker
        }
    }
}
