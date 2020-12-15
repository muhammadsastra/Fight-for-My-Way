using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthbar;
    public GameOver gameOver;
    
    public int Maxhealth = 100;
    public int health;
    private void Awake()
    {
        healthbar.SetMaxHealth(Maxhealth);
        health = Maxhealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthbar.setHealth(health);
        if (health <= 0)
        {
            gameOver.Dead();
            Destroy(gameObject);
        }
    }
    public void TambahDarah(int restore)
    {
        if (health < Maxhealth)
        {
            health += restore;
            healthbar.setHealth(health);

            if(health > Maxhealth)
            {
                health = Maxhealth;
            }
        }
    }
}
