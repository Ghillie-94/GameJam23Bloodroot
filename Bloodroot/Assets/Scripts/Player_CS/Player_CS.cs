using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Player_CS : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public static bool isGameOver;

    public HealthBar healthBar;

    void Start()
    {
        isGameOver = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            isGameOver = true;
        }
    }
}
