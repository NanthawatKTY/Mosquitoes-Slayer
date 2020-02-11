using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNormal : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Mosquito attackerRtoLPrefab;
  



    bool spawnRtoL = true;

    IEnumerator Start()
    {
        while (spawnRtoL)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(attackerRtoLPrefab, transform.position, transform.rotation);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
