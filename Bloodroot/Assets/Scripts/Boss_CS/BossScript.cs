using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed;
    

    public float timeBtwnShots;
    public float startTimeBtwnShots;

    public GameObject projectile;
   
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwnShots = startTimeBtwnShots;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (timeBtwnShots <= 0)
        {
            GameObject clonedProjectile;
            clonedProjectile = Instantiate(projectile);
            //Instantiate(projectile, transform.position, Quaternion.identity);
            clonedProjectile.transform.position = transform.position;
            timeBtwnShots = startTimeBtwnShots;
        }else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }
}
