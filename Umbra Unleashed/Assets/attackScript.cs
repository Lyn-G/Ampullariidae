using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        // i know how to use on trigger enter, but i forgot the exact syntax and asked chatgpt for an example and learned about
        // this function!
        if (other.CompareTag("Player"))
        {
            // set player state to hurt!

        }
    }
}
