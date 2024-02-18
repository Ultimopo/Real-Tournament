using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health;
    public int maxHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        if(health == 0)
        {
            health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();

        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
