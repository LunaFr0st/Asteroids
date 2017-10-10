using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public float health = 100f;
        public float damage = 10f;
        public float impactForce = 10f;
        public float attackTimer = 0f;
        public float attackRate = 5f;
        public float attackRadius = 10f;
        private bool isAttack = false;
        void Start()
        {

        }
        void Update()
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0f;
            }
        }
        public virtual void Attack()
        {
            isAttack = true;
        }
    }
}

