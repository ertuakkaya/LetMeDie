using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.5f; 
    public float dashSpeed = 10f;  
    public float dashDuration = 0.2f;  
    private bool isDashing = false;

    [SerializeField] public ParticleSystem dashEffect;
    [SerializeField] public ParticleSystem dashEffect1;

    private Rigidbody rb;
    
    public Light lanternLight;

    private float moveHorizontal = 0;
    private float moveVertical = 0;
    float r;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashEffect.Stop();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * 180;
        moveVertical = Input.GetAxis("Vertical") * 180;
        if (!(moveHorizontal == 0 && moveVertical == 0))
            MoveThePlayer();
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
            StartCoroutine(Dash());
        if (!isDashing)
        {
            dashEffect.Stop();
            dashEffect1.Stop();
        }
    }

    private void MoveThePlayer()
    {
        // Yürüme
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        rb.MoveRotation(Quaternion.LookRotation(movement)); 
        // Dönme
        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0, Angle, 0);
    }  
    
    IEnumerator Dash()
    {
        // Set dashing flag to true
        isDashing = true;

        Vector3 startPosition = transform.position;

        // Set the speed to dash speed
        speed = dashSpeed;

        // Wait for dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset speed to normal after dash is finished
        speed = 5.5f;

        // Reset dashing flag
        isDashing = false;

        dashEffect.Play();
        dashEffect1.Play();

        dashEffect.transform.position = startPosition;
    }
}