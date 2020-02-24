using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<FlashHealth>();
        var attacker = otherCollider.GetComponent<Flash>();

        if (attacker && health)
        {
            //Reduce Health
            health.DealDamage(damage);
            Destroy(gameObject);
        }
       
        
    }
}
