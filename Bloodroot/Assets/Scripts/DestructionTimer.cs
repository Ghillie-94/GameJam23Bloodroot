using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTimer : MonoBehaviour
{
    // Public variable
    public float goalTime; // number of seconds the object should live for (max time on the timer)

    //private variable
    private float startTime; // time stamp that our timer is starting at. (timestamp = seconds since game started)

    // Start is called before the first frame update
    void Start()
    {
        // Time.time = current time stamp (time since the game started)
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Declare a variable to contain our end timestamp to be used for comparisons
        float endTime;
        // The end timestamp is just the start timestamp plus how long the object should live (timer max)
        endTime = startTime + goalTime;

        //check if our current time is greater or equal to our end Time
        // If it is, perform our action
        if (Time.time >= endTime)
        {
            // Action: Destroy this object
            Destroy(gameObject);
        }
    }
}
