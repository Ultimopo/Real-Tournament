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

    public bool hasClips;
    public int clipsLeft = 7;

    public bool isMultiBullet;
    public int PelletCount = 12;

    public TextMeshProUGUI ammoLeftText;
    public TextMeshProUGUI MaxAmmoText;
    public TextMeshProUGUI clipsAmountText;


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

        //shotgun
        if(isMultiBullet && Input.GetKeyDown(KeyCode.Mouse0) && ammoLeft != 0)
        {
            for (int i = 0; i < PelletCount; i++)
            {

                Shoot();
            }
            ammoLeft--;
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            Reload();
        }

        if (isReloading == true)
        {
            timeToReload -= Time.deltaTime;
        }

        //clip reload
        if (timeToReload <= 0 && hasClips)
        {
            ammoLeft = maxAmmo;
            timeToReload = reloadTime;
            isReloading = false;
            clipsLeft = clipsLeft - maxAmmo;
        }

        //one by one reload
        if (timeToReload <= 0 && !hasClips)
        {
            if(ammoLeft != maxAmmo)
            {
                ammoLeft++;
                clipsLeft--;
            }
            else
            {
                isReloading = false;
            }
            timeToReload = reloadTime;
            
        }

        shootCooldown -= Time.deltaTime;

        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
        clipsAmountText.text = clipsLeft.ToString();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        if (!isMultiBullet)
        {
            ammoLeft--;
        }

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