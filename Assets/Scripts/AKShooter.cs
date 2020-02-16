using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, AKgun;
    

    public void Fire()
    {
        Instantiate(projectile, AKgun.transform.position, transform.rotation);
    }

}
