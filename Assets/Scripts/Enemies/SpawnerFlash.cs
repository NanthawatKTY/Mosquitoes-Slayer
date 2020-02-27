using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFlash : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Attacker FlashFlyPrefab;




    bool spawnRtoL = true;

    IEnumerator Start()
    {
        while (spawnRtoL)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnFlash();
        }
    }

    private void SpawnFlash()
    {
        Attacker newFlash = Instantiate(FlashFlyPrefab, transform.position, transform.rotation) as Attacker;
        newFlash.transform.parent = transform; // who flash is , where flash is

    }

    // Update is called once per frame
    void Update()
    {

    }
}
