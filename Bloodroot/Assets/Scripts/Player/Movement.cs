using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public variables
    public float movementForce = 10f;
    public float jumpPower = 30f;
    int jumpCounter = 0;
    bool grounded;
    bool hasMovedRight;

    bool jumpRequested = false;
    
     
    void Start()
    {
        grounded = true;
    }

    public void SetGrounded(bool newGrounded)
    {
        grounded = newGrounded;
        if (newGrounded)
        {
            jumpCounter = 0;
        }
    }

    public bool GetMovedRight()
    {
        return hasMovedRight;
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jumpRequested = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D>();
        ourRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")*movementForce,ourRigidbody.velocity.y);
        
        if (ourRigidbody.velocity.x > 0)
        {
            hasMovedRight = true;
        }
        else
        {
            hasMovedRight = false;
        }
        
        
        if (jumpRequested)
        {
            jumpRequested = false;
            if (jumpCounter < 2)
            {
                ourRigidbody.velocity = new Vector2(ourRigidbody.velocity.x, jumpPower);
                //ourRigidbody.AddForce(Vector2.up * jumpPower);
                jumpCounter ++;
                
            }  

        }
        

    }
    
}
