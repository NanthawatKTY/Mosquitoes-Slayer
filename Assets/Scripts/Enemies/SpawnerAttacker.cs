using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAttacker : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Attacker NormalPrefab;
  



    bool spawnRtoL = true;

    IEnumerator Start()
    {
        while (spawnRtoL)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnNormal();
        }
    }

    private void SpawnNormal()
    {
        Attacker newNormal = Instantiate(NormalPrefab, transform.position, transform.rotation) as Attacker;
        newNormal.transform.parent = transform; // who normal is , where normal is
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
