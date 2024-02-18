using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int ammoLeft;
    public int maxAmmo;


    public float timeToReload;
    public float reloadTime;
    float shootCooldown;
    public float shootInterval = 0.5f;


    bool isReloading = false;
    public bool isAutomatic;

    public TextMeshProUGUI ammoLeftText;
    public TextMeshProUGUI MaxAmmoText;


    void Start()
    {
        timeToReload = reloadTime;

        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
    }

    void Update()
    {
        //semiauto
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoLeft != 0 && !isAutomatic)
        {
            Shoot();
        }

        //auto
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0) && ammoLeft != 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            Reload();
        }

        if (isReloading == true)
        {
            timeToReload -= Time.deltaTime;
        }
        if (timeToReload <= 0)
        {
            ammoLeft = maxAmmo;
            timeToReload = reloadTime;
            isReloading = false;
        }
        shootCooldown -= Time.deltaTime;

        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        ammoLeft--;

        if (shootCooldown > 0) return;
        shootCooldown = shootInterval;

        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
        isReloading = false;
        timeToReload = reloadTime;

    }

    void Reload()
    {
        isReloading = true;
    }
}