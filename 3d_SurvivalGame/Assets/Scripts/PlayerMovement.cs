using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float speed = 13.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 1.0f;
    [SerializeField] private float jumpHeight = 3.0f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;

    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Jump();
        MoveAround();

    }

    private void MoveAround()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(movement * speed * Time.deltaTime);

    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
    }

    private void Jump()
    {
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity * gravityMultiplier);
        }

        velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

}
