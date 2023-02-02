using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowFire : MonoBehaviour
{
    // Unity editior variable
    public GameObject projectilePrefab;
    public Vector2 projectileVelocity;
    public Movement movement;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            FireCrossBowProjectile();
        }
    }

    public void FireCrossBowProjectile()
    {
        //clone the projectile
        //declare a variable to hold the cloned object
        GameObject clonedProjectile;
        // Use Instantiate to clone the projectile and keep the result in our variable
        clonedProjectile = Instantiate(projectilePrefab);

        //position the projectile on the player... tranform is the location of the script (the player object)
        clonedProjectile.transform.position = transform.position; //optional: add an offset (use a public variable)

        //fire in a direction
        //declare a variable to hold the cloned object's rigidbody
        Rigidbody2D projectileRigidbody;
        //get the rigidbody from our cloned projectile and store it
        projectileRigidbody = clonedProjectile.GetComponent<Rigidbody2D>();

        if (movement.GetMovedRight())
        {
            // Set the velocity on the rigidbody to the editor setting
            projectileRigidbody.velocity = projectileVelocity;
        }
        else
        {
            projectileRigidbody.velocity = -(projectileVelocity);
        }
    }
 }
