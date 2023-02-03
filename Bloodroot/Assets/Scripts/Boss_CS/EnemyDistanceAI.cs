using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceAI : MonoBehaviour
{
    //public variables (editable in unity and accessible to other scripts)
    public float distanceForDecision; //how close the player must be to change behaviour
    public Transform target;
    //add projectile script

    // Private variables 
    //private EnemyPatrol patrolBehaviour;
    private EnemyChase chaseBehaviour;


    // awake is called when the script loads
    void Awake()
    {
        //get the behaviours so we can turn them off and on
        //patrolBehaviour = GetComponent<EnemyPatrol>();
        chaseBehaviour = GetComponent<EnemyChase>();

        // Turn on the chase behaviour to start with
        chaseBehaviour.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // How far are we from our target?
        float distance = ((Vector2)target.position - (Vector2)transform.position).magnitude;

        //if we are further from our target than our minimum distance...
        if (distance >= distanceForDecision)
        {
            //Disable Homing and apply forward vector
            //patrolBehaviour.enabled = false;
            chaseBehaviour.enabled = false;

        }
        /*else
        {
            //enable patrol and disable chasing
            //patrolBehaviour.enabled = true;
            chaseBehaviour.enabled = false;
        }*/
    }
}
