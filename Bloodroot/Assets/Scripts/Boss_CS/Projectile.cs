using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float pSpeed;
    public Player_CS player_CS;

    private Transform Player;
    private Vector2 target;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

   
    void FixedUpdate()
    {
        target = new Vector2(Player.position.x, Player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, pSpeed * Time.deltaTime);
       
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
