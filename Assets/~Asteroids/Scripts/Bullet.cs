using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public string triggerTag = "Asteroid";
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == triggerTag)
            {
                Destroy(gameObject);
                Destroy(col.gameObject);
            }
        }
    }
}

