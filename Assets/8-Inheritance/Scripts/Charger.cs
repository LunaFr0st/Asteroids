using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float knockback = 10f;
        protected override void Update()
        {
            base.Update();
        }
        protected override void Attack()
        {
            base.Attack();
        }
    }
}

