using UnityEngine;

// This script makes the camera follow the player smoothly
public class CameraController : MonoBehaviour
{
    // Camera settings
    [SerializeField] private Transform playerTransform;  // Reference to player
    [SerializeField] private float distance = 5f;  // How far behind the player
    [SerializeField] private float height = 2f;  // How high above the player
    [SerializeField] private float smoothSpeed = 0.1f;  // How smooth the follow is
    [SerializeField] private float mouseSensitivity = 2f;  // How fast mouse rotates camera
    
    private float rotationX = 0f;  // Up/down rotation
    private float rotationY = 0f;  // Left/right rotation
    
    // START - runs once
    void Start()
    {
        // If no player assigned, find it
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    
    // LATE UPDATE - runs after Update (better for camera)
    void LateUpdate()
    {
        // Handle mouse input for camera rotation
        HandleMouseInput();
        
        // Follow the player
        FollowPlayer();
    }
    
    // Function to handle mouse input
    void HandleMouseInput()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Update rotation
        rotationY += mouseX;  // Left/right
        rotationX -= mouseY;  // Up/down
        
        // Clamp up/down rotation (don't let it go too far)
        rotationX = Mathf.Clamp(rotationX, -30f, 60f);
    }
    
    // Function to follow the player
    void FollowPlayer()
    {
        // Make sure we have a player
        if (playerTransform == null) return;
        
        // Calculate desired camera position
        Vector3 desiredPosition = playerTransform.position
            - playerTransform.forward * distance  // Behind player
            + Vector3.up * height;                 // Above player
        
        // Smoothly move camera to desired position
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );
        
        // Make camera look at player
        transform.LookAt(playerTransform.position + Vector3.up * 0.5f);
    }
}
