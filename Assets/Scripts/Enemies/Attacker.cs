using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    //[Range (0f,5f)]
    public float CurrentFlySpeed = 1f;
    GameObject CurrentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();  //Debug Null when restart
        if (levelController != null)
        {
           levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * CurrentFlySpeed * Time.deltaTime); //Use time.deltaTime to move gameObjects 

        UpdateAnimationAfterKilled();                    //Update Animation After Killed Defenders

    }

    private void UpdateAnimationAfterKilled()            //Update Animation After Killed Defenders
    {
        if (!CurrentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        CurrentFlySpeed = speed;
    }


    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        CurrentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!CurrentTarget)
        {
            return;
        }
        Health health = CurrentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    }


    void OnTriggerEnter2D(Collider2D otherCollider)   //Destroy GameObject when out of field
    {
        if (otherCollider.gameObject.name == "Damage Collider")
        {
           Destroy(gameObject);
        }
    }

   

}
