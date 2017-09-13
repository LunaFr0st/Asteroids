using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float timeAlive = 5f;
    void Update()
    {
        Destroy(gameObject, timeAlive);
    }
}
