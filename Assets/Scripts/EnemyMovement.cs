using System;
using UnityEngine;

// this script is attached to the enemy and it is for the enemy movement. such as following the player and patrolling

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
    [SerializeField] private bool isFollowTriggered; // patrol or follow player
    /// ////////////////
    
    
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
        Patrol();
    }
    
    private void FollowPlayer()
    {
        currentDistance = Vector3.Distance(transform.position, playerTransform.position);
        if (currentDistance ! > triggerDistance)
        {
            EnemyFollowEffect.Stop();
            isFollowTriggered = false; // if the player is far away, stop following
            return;
        }
        isFollowTriggered = true;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        EnemyFollowEffect.Play();
    }
    
    
    private void Patrol()
    {
        if (isFollowTriggered) return; // if the enemy is following the player, don't patrol
       
        if (transform.position != patrolPoints[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, patrolSpeed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
    
    // e�er oyuncu d��man�n trigger alan�na girerse, can� azal�r

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BloodController bloodController = BloodController.Instance;
            if (bloodController != null)
            {
                bloodController.ChangeBlood(-1);
                //Debug.Log("Player entered the enemy's trigger area. -10 blood is lost.");
            }
        }
    }
    
    
    
    
}