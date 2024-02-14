using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float speed = 5.0f; // Speed at which the enemy moves

    void Update()
    {


        
        
        // Move the enemy towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}