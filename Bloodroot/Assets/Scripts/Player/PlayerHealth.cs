using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    //This will be the starting health for player
    //public variable = shown in Unity editor and accessible from other scripts
    public int startingHealth;
    public string gameOverScene;
    public GameObject projectilePrefab;

    //this will be the player's current health
    //private variable: not shown in unity or accessible from other scripts
    private int currentHealth;
    private float sceneTimer = 1.2f;

    //built in unity function that is called when the object this script is attached to is created
    //usually this is when the game starts unless the object is spawned in later
    //this happens before the start() function
    //usually used for intialisation
    void Awake()
    {
        //intialise our current health to be equal to our...
        //... starting health at the beginning of the game 
        currentHealth = startingHealth;
    }

   
    
    //this function is not built into unity
    // it will only called manually by own code
    // it must be marked "public" so our other scripts can access It
    // this function will change the health value of the player
    public void ChangeHealth(int changeAmount)
    {
        //take our current health, add the change amount, and store the 
        //result back in the current health variable
        currentHealth = currentHealth + changeAmount;

        //we don't want our current health to go below zero
        //and we dont want it to go above our starting health 
        // so we use the special "Clamp" function to keep it
        //between 0 and our starting health 
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        //If our health has dropped to 0, that means our player should die.
        if (currentHealth == 0)
        {
            
            //we call the kill function to kill the player
            Kill();
        }

    }

    // This function is NOT built into unity!
    // It will only be called manually by our own code
    // It must be marked public so other scripts can access it.
    public void Kill()
    {
        //This will destroy the game object that this script is attatched to.
        Destroy(gameObject);

        // Explosion animation: spawn a prefab of explosion
        //clone the projectile
        //declare a variable to hold the cloned object
        GameObject clonedProjectile;
        // Use Instantiate to clone the projectile and keep the result in our variable
        clonedProjectile = Instantiate(projectilePrefab);

        //position the projectile on the player... tranform is the location of the script (the player object)
        clonedProjectile.transform.position = transform.position; //optional: add an offset (use a public variable)

        //Load the gameover scene 
        sceneTimer -= Time.deltaTime;
        if (sceneTimer >= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        
    }

     
    
    // This function will let other scripts ask this one what the current health is
    // the function RETURNS an integer, meaning it gives a number back to the code that called it
    public int GetHealth()
    {
        return currentHealth;
    }

    // This function will let other scripts ask this one what the max health is
    // the function RETURNS an integer, meaning it gives a number back to the code that called it
    public int GetMaxHealth()
    {
        return startingHealth;
    }
}
