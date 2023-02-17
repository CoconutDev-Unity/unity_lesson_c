using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _groundCheckDist = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Debug.DrawLine(transform.position, transform.position + Vector3.down * _groundCheckDist, Color.red);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 cameraForwardDir = cameraTransform.forward;
        cameraForwardDir.y = 0;
        Vector3 cameraRightDir = cameraTransform.right;
        cameraRightDir.y = 0;

        Vector3 movementDir = cameraForwardDir.normalized * vertical + cameraRightDir.normalized * horizontal;
        movementDir = Vector3.ClampMagnitude(movementDir, 1) * speed;
        rig.velocity = new Vector3(movementDir.x, rig.velocity.y, movementDir.z);

        rig.angularVelocity = new Vector3(0, 0, 0);

        float newAngleX = cameraTransform.rotation.eulerAngles.x - mouseY * mouseSensitivity;

        if (newAngleX > 180)
        {
            newAngleX = newAngleX - 360;
        }

        newAngleX = Mathf.Clamp(newAngleX, -80, 80);
        cameraTransform.rotation = Quaternion.Euler(newAngleX, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * mouseSensitivity, transform.rotation.eulerAngles.z);

        if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))
        {
            speed = 12;
        }
        else
        {
            speed = 6;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.Raycast(transform.position, Vector3.down, _groundCheckDist, LayerMask.GetMask("Default")))
            {
                rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}
