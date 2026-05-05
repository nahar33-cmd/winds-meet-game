using UnityEngine;

// This script controls how the player moves and acts
public class PlayerController : MonoBehaviour
{
    // Variables (like Scratch variables)
    [SerializeField] private float moveSpeed = 5f;  // How fast the player moves
    [SerializeField] private float sprintSpeed = 10f;  // How fast when sprinting
    [SerializeField] private float jumpForce = 5f;  // How high the player jumps
    
    private Rigidbody rb;  // Physics for the player
    private Vector3 moveDirection;  // Which direction the player is moving
    private bool isGrounded;  // Is the player on the ground?
    
    // START - runs once when the game starts
    void Start()
    {
        // Get the Rigidbody component (physics)
        rb = GetComponent<Rigidbody>();
    }
    
    // UPDATE - runs every frame (like Scratch forever loop)
    void Update()
    {
        // Check what the player is pressing
        HandleInput();
        
        // Check if player is on the ground
        CheckGround();
    }
    
    // FIXED UPDATE - runs for physics (every physics frame)
    void FixedUpdate()
    {
        // Move the player
        Move();
    }
    
    // This function handles keyboard input
    void HandleInput()
    {
        // Get input from keyboard (like Scratch "key pressed")
        // A and D for left/right
        // W and S for forward/backward
        float horizontal = Input.GetAxis("Horizontal");  // A/D or Left/Right arrows
        float vertical = Input.GetAxis("Vertical");      // W/S or Up/Down arrows
        
        // Create a direction from the input
        // normalized makes it so diagonal movement isn't faster
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        
        // Jump when pressing Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    
    // This function moves the player
    void Move()
    {
        // Check if player is holding Sprint (Left Shift)
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        
        // Move the player in the direction they pressed
        // Keep the Y velocity (gravity still works)
        rb.velocity = new Vector3(
            moveDirection.x * speed,           // X movement
            rb.velocity.y,                     // Keep current Y (don't change gravity)
            moveDirection.z * speed            // Z movement
        );
    }
    
    // This function makes the player jump
    void Jump()
    {
        // Add upward force
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);  // Reset Y velocity first
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);      // Jump!
    }
    
    // This function checks if player is touching the ground
    void CheckGround()
    {
        // Cast a ray downward from the player
        // If it hits something tagged "Ground", player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground"));
    }
}
