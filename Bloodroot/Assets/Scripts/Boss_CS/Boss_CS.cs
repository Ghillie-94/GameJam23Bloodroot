using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boss_CS : MonoBehaviour
{

    public int maxHealth = 250;
    public int currentHealth;
    public HealthBar healthBar;
    public string endScene;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(20);
        }
        if (currentHealth == 0)
        {
            Kill();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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

        SceneManager.LoadScene(endScene);
    }
}
