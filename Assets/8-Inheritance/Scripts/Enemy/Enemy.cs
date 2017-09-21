using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [Header("Base Enemy")]
        //Public
        public Transform target;
        public float damage = 50f;
        public float attackDur = 2f;
        public float attackRan = 2f;
        //Protected
        protected NavMeshAgent nav;
        protected Rigidbody rigi;
        //Private
        private float attackTimer = 0f;
        //Functions
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigi = GetComponent<Rigidbody>();
        }
        protected virtual void Attack()
        {

        }
        protected virtual void OnAttackEnd()
        {

        }
        protected virtual void Update()
        {
            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackDur)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if(distance < attackRan)
                {
                    StartCoroutine(AttackDelay(attackDur));
                    Attack();
                    attackTimer = 0f;
                }
            }
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

