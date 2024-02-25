using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public GameObject shellPrefab;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        rb.AddForce(transform.right.normalized * 200);
        rb.AddForce(transform.up.normalized * 200);
        Destroy(gameObject, 4f);
    }

    public void spawnShell()
    {
        Instantiate(shellPrefab, transform.position, transform.rotation);
    }
}
