using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public float health = 100f;
        public float damage = 10f;
        public float impactForce = 10f;
        public float attackDuration = 2f;
        public float attackRate = 1f;
        public float attackRadius = 10f;

        private float attackTimer = 0f;
        private bool isAttack = false;

        protected NavMeshAgent nav;
        public Transform target;
        protected Rigidbody rigi;
        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigi = GetComponent<Rigidbody>();
        }
        protected virtual void Update()
        {
            if (target == null)
            {
                return;
            }

            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if(distance <= attackRadius)
                {
                    Attack();
                    attackTimer = 0f;
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }
        }
        protected virtual void Attack()
        {
            isAttack = true;
        }
        protected virtual void OnAttackEnd()
        {

        }
        IEnumerator AttackDelay(float delay)
        {
            nav.Stop();
            yield return new WaitForSeconds(delay);
            nav.Resume();
            OnAttackEnd();
        }
        
    }
}

