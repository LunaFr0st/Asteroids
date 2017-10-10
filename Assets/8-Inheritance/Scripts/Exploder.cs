using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Exploder : Enemy
    {
        [Header("Exploder")]
        public float explosionRad = 10f;
        public GameObject explosionParticles;

        public override void Attack()
        {
            base.Attack();
        }
    }
}
