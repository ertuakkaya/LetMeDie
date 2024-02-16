using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float speed = 5.0f; // Speed at which the enemy moves

    [SerializeField] public ParticleSystem EnemyFollowEffect;

    [SerializeField] private float currentDistance = 10f;
    [SerializeField] private float triggerDistance = 5f;
    
    
    // for enemy patrol
    public Transform[] patrolPoints;
    private int currentPoint;
    public float patrolSpeed;
    
    
    
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        EnemyFollowEffect.Stop();
    }

    private void Start()
    {
        // for enemy patrol
        currentPoint = 0;
    }


    void Update()
    {
        FollowPlayer();
        if (currentDistance > triggerDistance)
        {
            EnemyFollowEffect.Stop();
        }
        
        Patrol();
        
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
    
    
    private void Patrol()
    {
        if (transform.position != patrolPoints[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, patrolSpeed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}