using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Transform target;
    public float gap = 3f;
    public float rotSpeed = 3f;

    public float minVerAngle = -14f;
    public float maxVerAngle = 45f;
    public Vector2 framingBalance;
    float rotx;
    float roty;
    public bool invertX;
    public bool invertY;
    float invertXValue;
    float invertYValue;
    // Start is called before the first frame update
    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    private void Update()
    {
        invertXValue = (invertX) ? -1 : 1;
        invertYValue = (invertY) ? -1 : 1;

        rotx += Input.GetAxis("Mouse Y") * invertYValue * rotSpeed;
        rotx = Mathf.Clamp(rotx, minVerAngle, maxVerAngle);
        roty += Input.GetAxis("Mouse X") * invertXValue * rotSpeed;

        var targetRotation = Quaternion.Euler(rotx, roty, 0);
        var focusPos = target.position + new Vector3(framingBalance.x, framingBalance.y);

        transform.position = focusPos - targetRotation * new Vector3(0, 0, gap);
        transform.rotation = targetRotation;
    }

    public Quaternion flatRotation => Quaternion.Euler(0, roty, 0);

    // public Quaternion flatRotation(){
    //     return Quaternion.Euler(0, roty, 0);
    // }
}
