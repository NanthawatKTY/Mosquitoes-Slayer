using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagement : MonoBehaviour
{

    public static AudioClip GunHitSound, FireSound, StarPumpSound, enemyDeadSound, DefenderDeathSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        GunHitSound = Resources.Load<AudioClip>("RobloxDeathSound");
        FireSound = Resources.Load<AudioClip>("piggy_plop");
        enemyDeadSound = Resources.Load<AudioClip>("SPLAT");
        DefenderDeathSound = Resources.Load<AudioClip>("BRUH");
        StarPumpSound = Resources.Load<AudioClip>("qurazy_quoin");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) 
        {
            case "RobloxDeathSound":
                audioSrc.PlayOneShot(GunHitSound);
                break;
            case "piggy_plop":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "SPLAT":
                audioSrc.PlayOneShot(enemyDeadSound);
                break;
            case "BRUH":
                audioSrc.PlayOneShot(DefenderDeathSound);
                break;
            case "qurazy_quoin":
                audioSrc.PlayOneShot(StarPumpSound);
                break;
        }
    }
}
