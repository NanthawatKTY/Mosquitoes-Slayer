using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBigboy : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Bigboy BigboyPrefab;




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
        Instantiate(BigboyPrefab, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
