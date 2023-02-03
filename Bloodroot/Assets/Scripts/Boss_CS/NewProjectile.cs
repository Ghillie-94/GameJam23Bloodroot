using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile : MonoBehaviour
{
    public float pSpeed;
    public float unlockSpeed;
    public Player_CS player_CS;
    public float distanceForUnlock;
    
    

    private Transform Player;
    private Vector2 target;
    private Vector2 unlock;
    private bool isLockedOn = true;
    private Rigidbody2D thisRigidbody;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    void GetPosition()
    {
        unlock = target;
    }


    void FixedUpdate()
    {
        target = new Vector2(Player.position.x, Player.position.y);
        
        // How far are we from our target?
        float distance = (target - (Vector2)transform.position).magnitude;
        if (distance > distanceForUnlock && isLockedOn)
        {
            // move in the direction of our target
            // Get the direction
            Vector2 direction = (target - (Vector2)transform.position).normalized;

            // move in the correct direction with the set force strength
            thisRigidbody.AddForce(direction * pSpeed);
        }
        else
        {
            isLockedOn = false;
            GetPosition();
            
            // move in the direction of our targets last location before unlock
            // Get the direction
            Vector2 direction = (unlock - (Vector2)transform.position).normalized;

            // move in the correct direction with the set force strength
            thisRigidbody.AddForce(direction * unlockSpeed);
        }
        



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
          
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

