using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public variables
    float movementForce = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();
        ourRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")*movementForce,0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ourRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * movementForce, 2);
        }
    }
}
