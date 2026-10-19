using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody2D rb; 

    private InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get input from the player for horizontal and vertical movement

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        Vector2 moveVelocity = moveInput * movementSpeed * Time.fixedDeltaTime;
        rb.linearVelocity = moveVelocity;

    }

}
