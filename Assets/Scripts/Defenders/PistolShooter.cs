using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooter : MonoBehaviour
{
    [SerializeField] GameObject PistolProjectile, PistolGun;

    public void PistolFire()
    {
        Instantiate(PistolProjectile, PistolGun.transform.position, transform.rotation);
    }
 
}
