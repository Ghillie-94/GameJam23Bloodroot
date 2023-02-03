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
    SpriteRenderer spriteRenderer;

    bool jumpRequested = false;
    
     
    void Start()
    {
        grounded = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        

        float currentSpeedH = ourRigidbody.velocity.x;
        // get animator component that will be used for setting animation
        Animator ourAnimator = GetComponent<Animator>();

        // tell animator what the speed is
        ourAnimator.SetFloat("speedH", currentSpeedH);

        if (ourRigidbody.velocity.x > 0)
        {
            hasMovedRight = true;
            spriteRenderer.flipX = false;
        }
        else if (ourRigidbody.velocity.x < 0)
        {
            hasMovedRight = false;
            spriteRenderer.flipX = true;

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
