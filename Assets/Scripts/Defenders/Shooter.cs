using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, Gun;
    SpawnerAttacker myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane() )
        {

            animator.SetBool("IsAttacking",true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

    }

    private void SetLaneSpawner()
    {
        SpawnerAttacker[] spawners = FindObjectsOfType<SpawnerAttacker>();

        foreach (SpawnerAttacker spawner in spawners)
        {
            bool IsCloseEnough = 
                
            Mathf.Floor(Mathf.Abs(spawner.transform.position.y - transform.position.y)) <= Mathf.Epsilon;
            // turn into plus

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }

    }

    private bool IsAttackerInLane()
    {
        if ( myLaneSpawner.transform.childCount <= 0)
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
        Instantiate(projectile, Gun.transform.position, transform.rotation);
    }

}
