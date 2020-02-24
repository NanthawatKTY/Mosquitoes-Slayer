using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFlash : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Flash FlashFlyPrefab;




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
        Flash newFlash = Instantiate(FlashFlyPrefab, transform.position, transform.rotation) as Flash;
        newFlash.transform.parent = transform; // who flash is , where flash is

    }

    // Update is called once per frame
    void Update()
    {

    }
}
