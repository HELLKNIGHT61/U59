using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.T))
        {
            ani.SetBool("Boss", true);
            
        }
        else
        {
            ani.SetBool("Boss", false);
        }
        



    }

    
}
