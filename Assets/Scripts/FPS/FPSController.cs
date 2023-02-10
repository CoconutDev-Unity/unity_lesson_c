using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movemenDir = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        movemenDir = new Vector3(movemenDir.x, rig.velocity.y, movemenDir.z);
        rig.velocity = Vector3.ClampMagnitude(movemenDir, 1) * speed;

        rig.angularVelocity = new Vector3(0, 0, 0);

        if (cameraTransform.rotation.eulerAngles.x - mouseY > 280 || cameraTransform.rotation.eulerAngles.x - mouseY < 90) {
            cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x - mouseY * mouseSensitivity, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * mouseSensitivity, transform.rotation.eulerAngles.z);

    }
}
