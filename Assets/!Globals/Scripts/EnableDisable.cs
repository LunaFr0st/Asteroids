using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    private AudioSource myAudio;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        int i = 1;
        
        myAudio.pitch = i;
        myAudio.Play();
        i++;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Kek");
        }
    }
}
