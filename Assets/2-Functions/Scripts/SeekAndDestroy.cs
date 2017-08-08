﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndDestroy : MonoBehaviour
{
    public float AliveTime = 1f;


    // Use this for initialisation (Corrected spelling for Australian English)
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroys the gameObject the script is attached to after a period of time
        
        Destroy(gameObject, AliveTime);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
