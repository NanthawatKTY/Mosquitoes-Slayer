﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKProjectile : MonoBehaviour
{

    [SerializeField] float speed ;
    [SerializeField] float damage ;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
        var health = otherCollider.GetComponent<FlashHealth>();
        var attacker = otherCollider.GetComponent<Flash>();
        //Reduce Health
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        else if (otherCollider.gameObject.name == "DestroyOut")
        {
            Destroy(gameObject);
        }

    }
}