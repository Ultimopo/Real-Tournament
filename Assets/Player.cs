using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public TextMeshProUGUI healthText;

    [Header("Components")]
    public Health health;



    // Start is called before the first frame update
    void Awake()
    {
        health.onDamage.AddListener(updateUI);
        healthText.text = health.health.ToString() + "HP";
    }


    void Update()
    {
    }


    public void updateUI()
    {
        healthText.text = health.health.ToString() + "HP";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health.Damage(10);

        }
    }
    
    public void Respawn()
    {
        health.health = health.maxHealth;
        transform.position = Vector3.zero;

    }

}
