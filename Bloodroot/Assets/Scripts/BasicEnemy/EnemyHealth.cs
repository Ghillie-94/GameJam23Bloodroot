using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 250;
    public int currentHealth;
    
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth == 0)
        {
            Kill();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        //we don't want our current health to go below zero
        //and we dont want it to go above our starting health 
        // so we use the special "Clamp" function to keep it
        //between 0 and our starting health 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    }

    public void Kill()
    {
        //This will destroy the game object that this script is attatched to.
        Destroy(gameObject);

    }
}
