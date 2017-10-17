using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Exploder : Enemy
    {
        [Header("Exploder")]
        public float explosionRad = 10f;
        public float explosionRate = 1f;
        private float explosionTimer = 0f;
        public GameObject explosionParticles;
        public AudioSource wow;

        protected override void Awake()
        {
            base.Awake();
            wow = GetComponent<AudioSource>();
        }
        protected override void Update()
        {
            base.Update();
        }
        protected override void Attack()
        {
            base.Attack();
            explosionTimer += Time.deltaTime;
            if (explosionTimer >= explosionRate)
            {
                Explode();
                
            }
        }
        protected override void OnAttackEnd()
        {

        }
        public void Explode()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRad);
            foreach (Collider hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                    rigi.AddExplosionForce(impactForce, transform.position, explosionRad);
                    wow.Play();
                }
            }

        }
    }
}
