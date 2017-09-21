using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrphanSelfOnStart : MonoBehaviour
{
    void Start()
    {
        transform.SetParent(null);
    }
}
