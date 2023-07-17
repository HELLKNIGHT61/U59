using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : MonoBehaviour
{

    public Transform target;
    public float gap = 4.1f;
    float rotX;
    float rotY;

    // Update is called once per frame
    private void Update()
    {
        rotX += Mouse.current.position.x.ReadValue();
        rotY += Mouse.current.position.y.ReadValue();

        transform.position = target.position - new Vector3(0, -2, gap);
    }
}
