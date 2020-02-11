using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{


    public int health;

    [Range(0f, 5f)]
    public float CurrentFlySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
}
