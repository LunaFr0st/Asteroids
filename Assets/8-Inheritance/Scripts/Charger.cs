using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float knockback = 10f;

        public override void Attack()
        {
            base.Attack();
        }
    }
}

