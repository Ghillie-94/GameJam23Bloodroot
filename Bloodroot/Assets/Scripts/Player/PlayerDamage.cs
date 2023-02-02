using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerDmg;

    //CONDITION: when the projectile hits a certain object type... (enemy)
    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        
        Boss_CS enemyBoss = otherCollider.GetComponent<Boss_CS>();
        

        //Check if the object we collided with has the tag we are looking for (Enemy)
        if (otherCollider.CompareTag("Enemy"))
        {
            //perform our action
            enemyBoss.TakeDamage(playerDmg);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    //ACTION: Destroy an object (enemy)
    public void KillEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
