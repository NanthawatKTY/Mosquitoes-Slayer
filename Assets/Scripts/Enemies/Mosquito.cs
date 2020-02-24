﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mosquito : MonoBehaviour
{


 
    float CurrentFlySpeed ;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * CurrentFlySpeed * Time.deltaTime);
    }
    public void SetMovementSpeed(float speed)
    {
        CurrentFlySpeed = speed;
    }

  

}

