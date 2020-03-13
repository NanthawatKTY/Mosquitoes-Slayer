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

        
        foreach (SpawnerAttacker spawner in spawners) //Keep spawners array values into spawner 
        {
            bool IsCloseEnough =

            //Mathf.Floor = ทำให้ larges number กลายเป็น smaller or equal to float such as 10.1 = 10, 10.9 = 10, -10.0 = -10, -10.5 = -11
            //Mathf.Abs remove sign (-) in result 
            //Mathf.Epsilon = 0.00000000000001
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
        else
        {
            return true;
        }

    }

    public void Fire()
    {
        SFXManagement.PlaySound("piggy_plop"); //SFX On Fire

        GameObject newProjectile = Instantiate(projectile, Gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }


    //if enemy is ahead of the defender

    //////public bool IsAttackerAheadInLane()
    //////{
    //////    int childCount = myLaneSpawner.transform.childCount;
    //////    if (childCount > 0)
    //////    {
    //////        //check if the enemy is ahead of the defender
    //////        for (int i = 0; i < childCount; i++)
    //////        {
    //////            if (myLaneSpawner.transform.GetChild(i).transform.position.x > gameObject.transform.position.x)
    //////            {
    //////                return true;
    //////            }
    //////        }
    //////    }
    //////    return false;
    //////}

}
