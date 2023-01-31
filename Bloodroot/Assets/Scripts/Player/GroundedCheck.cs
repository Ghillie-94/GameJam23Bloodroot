using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public Movement movement;
    
    

    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.CompareTag("Floor"))
        {
            movement.SetGrounded(true);
        }
    }
    void OnTriggerExit2D(Collider2D otherCollider)
    {

        if (otherCollider.CompareTag("Floor"))
        {
            movement.SetGrounded(false);
            
        }
    }

}
