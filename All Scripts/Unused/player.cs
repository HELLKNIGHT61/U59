using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class player : MonoBehaviour

{

    public Animator playerAnim;

    public Rigidbody playerRigid;

    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;

    public bool walking;

    public Transform playerTrans;

    public float rotationSpeed = 100f; // Donus hizi
    public string doorTag = "Door"; // Kapi etiketi bu olcak

    public float jumpForce = 20.0f;
    public bool isJumping;
    private bool isGrounded;
    private float distToGround;

    void Start()
    {
        // Bu ne kadar mesafe oldugu
        distToGround = GetComponent<Collider>().bounds.extents.y;

        playerRigid.useGravity = true;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward * w_speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward * wb_speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right * ro_speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right * ro_speed;
        }

        // Vertical snapping
        if (!isJumping && Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
        {
            moveDirection.y = -1;
        }

        playerRigid.velocity = moveDirection * Time.deltaTime;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        // Add gravity manually for more tuning control
        playerRigid.AddForce(new Vector3(0, -9.81f * playerRigid.mass, 0));

        // Add Jumping feature
        if (!isJumping && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            playerAnim.SetTrigger("jump");
            playerAnim.ResetTrigger("idle");
            isJumping = true;
        }

        float horizontalMouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, horizontalMouseMovement * rotationSpeed * Time.deltaTime, 0));

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
            //steps1.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
            //steps1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("back_walk");
            playerAnim.ResetTrigger("idle");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("back_walk");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("back_left");
            playerAnim.ResetTrigger("idle");
        }
        else if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("back_left");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("back_right");
            playerAnim.ResetTrigger("idle");
        }
        else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("back_right");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("left");
            playerAnim.ResetTrigger("idle");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.ResetTrigger("left");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("right");
            playerAnim.ResetTrigger("idle");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.ResetTrigger("right");
            playerAnim.SetTrigger("idle");
        }

        if (walking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("walk");
        }
        else if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("walk");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // or whatever tag you use for the ground
        {
            isJumping = false;
        }
    }
}