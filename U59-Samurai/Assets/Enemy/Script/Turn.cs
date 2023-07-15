using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public float rotationOffset = 90f;
    public GameObject projectile;
    public Transform projectilePoint;
   

    bool isAttacking = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = anim.GetBool("isAttacking");

        if(isAttacking)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            desiredRotation *= Quaternion.Euler(0f, rotationOffset, 0f);

            transform.rotation = desiredRotation;
            Debug.Log("calisti");
        }
        

        
    }

    public void Shoot()
    {
        
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.Euler(90f, 0f, 0f)).GetComponent<Rigidbody>();
        rb.AddForce(-transform.right * 50f, ForceMode.Impulse);
        
    }
}
