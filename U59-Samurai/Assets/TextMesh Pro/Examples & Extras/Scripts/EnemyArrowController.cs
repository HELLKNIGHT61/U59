using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowController : MonoBehaviour
{
    Animator ErikaAnim;
    void Aweke()
    {
       ErikaAnim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            ErikaAnim.SetFloat("hiz", 0.4f);
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
            {
                ErikaAnim.SetFloat("hiz", 1f);
            }
        }
        else 
        {
         ErikaAnim.SetFloat("hiz", 0f);
        }
         
    }
}
