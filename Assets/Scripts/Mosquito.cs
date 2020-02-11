using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mosquito : MonoBehaviour
{
    public int health;
    private float dazedTime;
    public float startDazedTime;

    [Range(0f, 5f)]
    public float CurrentFlySpeed ;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            CurrentFlySpeed = 2;
        }
        else 
        {
            CurrentFlySpeed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);

        }
            transform.Translate(Vector2.left * CurrentFlySpeed * Time.deltaTime);

    }
    public void SetMovementSpeed(float speed)
    {
        CurrentFlySpeed = speed;
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("Damage Taken");
    }
  

}


