using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public float duration = 3f;
    private Vector3 spawnPos;
    private Renderer rend;
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    void Start()
    {
        spawnPos = transform.position;
    }
    public void Spawn()
    {
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = spawnPos;
        rend.enabled = true;
    }
}
