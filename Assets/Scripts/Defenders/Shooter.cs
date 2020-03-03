using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, Gun;
    SpawnerAttacker myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectile";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);

        }
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
        if (myLaneSpawner == null || myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
            return true;

    }

    public void Fire()
    {
        SFXManagement.PlaySound("piggy_plop"); //SFX On Fire

        GameObject newProjectile = Instantiate(projectile, Gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
