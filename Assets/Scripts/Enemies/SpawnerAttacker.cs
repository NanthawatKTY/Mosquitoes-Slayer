using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAttacker : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Attacker[] attackerPrefabArray;
  



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
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform; // who normal is , where normal is  
    }


}
