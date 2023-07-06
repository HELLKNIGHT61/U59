using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform thirdPersonCameraTarget;
    public Transform firstPersonCameraTarget;

    public float zoomSpeed = 1.92f;
    public float minZoom = 2.048f;
    public float maxZoom = 6400f;

    private bool isThirdPerson = true;
    private float currentZoom;

    private void Start()
    {
        currentZoom = (maxZoom + minZoom) / 4f; // set initial zoom level to the midpoint between max and min
        UpdateCameraPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isThirdPerson = !isThirdPerson; // toggle between first and third person
        }

        if (isThirdPerson)
        {
            // adjust zoom level based on mouse scroll input
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }

        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        if (isThirdPerson)
        {
            // position camera in third person view, adjust distance based on zoom level
            transform.position = thirdPersonCameraTarget.position - thirdPersonCameraTarget.forward * currentZoom;
            transform.LookAt(thirdPersonCameraTarget.position);
        }
        else
        {
            // position camera in first person view
            transform.position = firstPersonCameraTarget.position;
            transform.rotation = firstPersonCameraTarget.rotation;
        }
    }
}