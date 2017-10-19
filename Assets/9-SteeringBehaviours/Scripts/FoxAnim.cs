using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class FoxAnim : MonoBehaviour
{
    private Animator anim;
    private Vector3 prevPos;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 currPos = transform.position;
        float moveSpeed = (prevPos - currPos).magnitude;
        anim.SetFloat("moveSpeed", moveSpeed);
        prevPos = currPos;
    }
}
