﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAtk : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider) //กำหนด > otherCollider
    {
        GameObject otherObject = otherCollider.gameObject; //กำหนด otherObject = otherCollider ของ gameObject


        //if this is Shield then do......
        if (otherObject.GetComponent<Shield>())
        {
            GetComponentInChildren<Animator>().SetTrigger("JumpTrigger");
        
        }

        else if (otherObject.GetComponent<Defenders>()) //ถ้าเป็น Defenders 
        {
            GetComponent<Attacker>().Attack(otherObject); //ให้ทำการ Attack จาก Attack() of Attacker.cs
        }
    }
}
