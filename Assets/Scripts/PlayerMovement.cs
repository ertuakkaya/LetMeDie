using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f; // Regular movement speed
    public float dashSpeed = 10f; // Speed of the dash
    public float dashDuration = 0.2f; // Duration of the dash
    private bool isDashing = false; // Flag to check if player is dashing

    private Rigidbody rb;
    
    public Light lanternLight;

    private float moveHorizontal = 0;
    private float moveVertical = 0;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        
        PlayerMoveNDash();
    }

    private void PlayerMoveNDash()
    {
        if (moveHorizontal == 0 && moveVertical == 0) return;
        
        
        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        // If dash button is pressed and player is not already dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // Apply movement
        rb.MovePosition(transform.position + movement);
        rb.MoveRotation(Quaternion.LookRotation(movement)); // Rotate player to face movement direction
    }
    
    
    IEnumerator Dash()
    {
        // Set dashing flag to true
        isDashing = true;

        // Set the speed to dash speed
        speed = dashSpeed;

        // Wait for dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset speed to normal after dash is finished
        speed = 5.5f;

        // Reset dashing flag
        isDashing = false;
    }
}