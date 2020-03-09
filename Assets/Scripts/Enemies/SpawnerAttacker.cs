using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAttacker : MonoBehaviour
{
    [SerializeField] float minSpawnDelay ;
    [SerializeField] float maxSpawnDelay ;
    [SerializeField] Attacker[] attackerPrefabArray;
  



    bool spawnRtoL = true;

    IEnumerator Start()
    {
        while (spawnRtoL)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawnRtoL = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform; // who normal is , where normal is  
    }

    internal object GetChild(int i)
    {
        throw new NotImplementedException();
    }
}
