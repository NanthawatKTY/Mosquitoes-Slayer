using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, AKgun;
    SpawnerFlash myLaneSpawner;
    Animator AK_Animator;

    private void Start()
    {
        SetLaneSpawner();
        AK_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        { 
      
            AK_Animator.SetBool("IsAttacking",true);
        }
        else
        {
            AK_Animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        SpawnerFlash[] spawners = FindObjectsOfType<SpawnerFlash>();

        foreach (SpawnerFlash spawner in spawners)
        {
            bool IsCloseEnough = 
                
            Mathf.Floor(Mathf.Abs((spawner.transform.position.y - transform.position.y))) <= Mathf.Epsilon;
            // turn into plus

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
         
            return true;
          
        }
    }

    public void Fire()
    {
        Instantiate(projectile, AKgun.transform.position, transform.rotation);
    }

}
