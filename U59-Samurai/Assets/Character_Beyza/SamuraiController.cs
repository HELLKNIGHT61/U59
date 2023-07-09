using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotSpeed = 450f;
    public float currentSpeed = 0f;
public int transitionSpeed = 8;
    public MainCameraController cameraController;
    public CharacterController charController;
    public Animator anim;
    Quaternion requireRotation;

    private void Update(){
        PlayerMovement();
    }

    void PlayerMovement(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movementInput = (new Vector3(horizontal, 0, vertical)).normalized;
        var direction = cameraController.flatRotation* movementInput;

        if(movementAmount > 0){
            charController.Move(direction * movementSpeed * Time.deltaTime);
            requireRotation = Quaternion.LookRotation(direction);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requireRotation, rotSpeed * Time.deltaTime);
        anim.SetFloat("movement", movementAmount, 0.2f, Time.deltaTime);
        anim.SetFloat("runTrigger", currentSpeed);

if (Input.GetKey(KeyCode.LeftShift) && currentSpeed <= 1f)
{
currentSpeed += 0.1f * Time.deltaTime * transitionSpeed;
}
else
{
if (currentSpeed >= 0f)
{
currentSpeed -= 0.1f * Time.deltaTime * transitionSpeed;
}
}}
}
