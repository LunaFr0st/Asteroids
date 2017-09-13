﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f; // Sets the Enemies health
        public void DealDamage(float damage)
        {
            health -= damage;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

