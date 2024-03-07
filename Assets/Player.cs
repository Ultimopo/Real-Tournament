using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public TextMeshProUGUI healthText;

    [Header("Components")]
    public Health health;
    public Weapon weapon;
    public LayerMask weaponLayer;
    public GameObject grabText;
    public Transform hand;

    AudioSource source;

    public AudioClip pickup;
    public AudioClip shoot;


    // Start is called before the first frame update
    void Awake()
    {
        health.onDamage.AddListener(updateUI);
        healthText.text = health.health.ToString() + "HP";
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, weaponLayer);
        grabText.SetActive(collided);



            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (!weapon && collided)
                {
                    Grab(hit.collider.gameObject);
                }
                else
                {
                    Drop();
                }
            }


        if (weapon == null) return;

        //semiauto
        if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.ammoLeft != 0 && !weapon.isAutomatic)
        {
            weapon.Shoot();
        }

        //auto
        if (weapon.isAutomatic && Input.GetKey(KeyCode.Mouse0) && weapon.ammoLeft != 0)
        {
            weapon.Shoot();
        }

        //shotgun
        if (weapon.isMultiBullet && Input.GetKeyDown(KeyCode.Mouse0) && weapon.ammoLeft != 0)
        {
            for (int i = 0; i < weapon.PelletCount; i++)
            {

                weapon.Shoot();
            }
            source.PlayOneShot(shoot);
            weapon.ammoLeft--;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && weapon.isReloading == false)
        {
            weapon.Reload();
        }


    }
    public void Grab(GameObject gun)
    {
        if (weapon != null) return;
        print(gun.name);
        weapon = gun.GetComponent<Weapon>();
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
        source.PlayOneShot(pickup);
    }
    public void Drop()
    {
        if (weapon == null) return;
        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.transform.parent = null;
        weapon = null;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Ammo"))
        {
            weapon.clipsLeft = weapon.clipsLeft + 3;
            Destroy(other.gameObject);
        }
    }

    public void Respawn()
    {
        health.health = health.maxHealth;
        transform.position = Vector3.zero;

    }

}
