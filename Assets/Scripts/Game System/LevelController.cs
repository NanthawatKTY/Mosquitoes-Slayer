using System.Collections;
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
        numberOfMosquito++;
    }

    public void AttackerKilled()
    {
        numberOfMosquito--;
        
        if (numberOfMosquito <= 0 && levelTimerFinished) 
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();             //Play Audio
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() //Stop spawning
    {
        SpawnerAttacker[] spawnerArray = FindObjectsOfType<SpawnerAttacker>();
        foreach (SpawnerAttacker spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
