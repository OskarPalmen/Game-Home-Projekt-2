using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputAction playerControls;
    Vector2 moveDirection = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        // Read the input value of the player controls
        moveDirection = playerControls.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        // Enable the player controls input action
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Disable the player controls input action
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        // Set the velocity of the rigidbody based on the move direction and move speed
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
