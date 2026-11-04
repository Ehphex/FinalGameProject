using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    public float movementSpeed = 5f;

    private Rigidbody2D rb; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get input from the player for horizontal and vertical movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float sprintMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f; // Sprint multiplier when Left Shift is held down

        Vector2 moveInput = new Vector2(moveX, moveY);
        moveInput.Normalize();
        Vector2 moveVelocity = moveInput * movementSpeed * Time.fixedDeltaTime * sprintMultiplier;
        rb.linearVelocity = moveVelocity;

        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            transform.position = spawnPoint.transform.position;
            Destroy(other.gameObject); // Move the player to the spawn point
        }
    }

}
