using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    float turnSmoothVelocity;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = 20f; // Adjust gravity as per your needs

    private float verticalVelocity = 0f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Apply gravity
        if (!controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            controller.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
        }
        else
        {
            // Reset vertical velocity when grounded
            verticalVelocity = 0f;
        }
    }
}
