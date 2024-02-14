using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float speed = 5.0f; // Speed at which the enemy moves

    
    
    [SerializeField] private float currentDistance = 10f;
    [SerializeField] private float triggerDistance = 5f;
    

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
        // Move the enemy towards the player
    }
    
    private void FollowPlayer()
    {
        currentDistance = Vector3.Distance(transform.position, playerTransform.position);
        if (currentDistance !> triggerDistance) return;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}