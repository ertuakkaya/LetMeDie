using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float speed = 5.0f; // Speed at which the enemy moves

    [SerializeField] public ParticleSystem EnemyFollowEffect;

    [SerializeField] private float currentDistance = 10f;
    [SerializeField] private float triggerDistance = 5f;
    

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        EnemyFollowEffect.Stop();
    }

    void Update()
    {
        FollowPlayer();
        if (currentDistance > triggerDistance)
        {
            EnemyFollowEffect.Stop();
        }
        
    }
    
    private void FollowPlayer()
    {
        currentDistance = Vector3.Distance(transform.position, playerTransform.position);
        if (currentDistance !> triggerDistance) return;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        EnemyFollowEffect.Play();
    }
    
    
    private void FollowAndMove()
    {
        float minDistance = 5f; // Minimum distance for the enemy to start following the player
        float maxDistance = 15f; // Maximum distance for the enemy to stop following the player

        currentDistance = Vector3.Distance(transform.position, playerTransform.position);

        if (currentDistance > minDistance && currentDistance < maxDistance)
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);      
        }
    }
}