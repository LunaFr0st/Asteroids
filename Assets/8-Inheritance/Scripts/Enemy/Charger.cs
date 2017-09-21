﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float chargeSpeed = 20f;
        public float knockback = 5f;
    }
}

