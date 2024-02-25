using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public bool shouldDestroy = true;

    public GameObject damageEffect;
    public GameObject deathEffect;

    public UnityEvent onDamage;
    public UnityEvent onDie;


    // Start is called before the first frame update
    void Awake()
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
        onDamage.Invoke();
        health -= damage;
        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            Die();

        }
    }

    public void Die()
    {
        onDie.Invoke();
        if(shouldDestroy)Destroy(gameObject);
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
