using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    // Public variables
    public float forceStrength; // how fast we move
    public Transform target; // the thing you want to chase!
    

    //private variables
    private Rigidbody2D ourRigidbody; // the rigidbody attached to this object for movement


    // Awake is called when the script first loads
    void Awake()
    {
        // get the rigidbody that we'll be using for movement
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move in the direction of our target

        // Get the direction
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;

        // move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);
    }
}
