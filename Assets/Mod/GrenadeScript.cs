using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject explosionPrefab;

    public int damage = 10;
    public int bounceCount = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(transform.forward.normalized * 1500);
    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy(gameObject);



        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
        if (bounceCount > 0)
        {
            transform.forward = other.contacts[0].normal;
            bounceCount--;
        }
        else
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
