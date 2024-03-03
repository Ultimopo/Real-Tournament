using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shellPrefab;

    public int ammoLeft;
    public int maxAmmo;


    public float timeToReload;
    public float reloadTime;
    float shootCooldown;
    public float shootInterval = 0.5f;


    public bool isReloading = false;
    public bool isAutomatic;

    public bool hasClips;
    public int clipsLeft = 7;

    public bool isMultiBullet;
    public int PelletCount = 12;

    public float spreadAngle = 5;

    public TextMeshProUGUI ammoLeftText;
    public TextMeshProUGUI MaxAmmoText;
    public TextMeshProUGUI clipsAmountText;



    public UnityEvent onRightClick;
    public UnityEvent onShoot;

    AudioSource source;

    
    public AudioClip reload;
    public AudioClip shotgunfinish;

    void Start()
    {
        timeToReload = reloadTime;
        source = GetComponent<AudioSource>();


        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            Reload();
        }

        if (isReloading && clipsLeft != 0)
        {
            timeToReload -= Time.deltaTime;
        }

        //clip reload
        if (timeToReload <= 0 && hasClips)
        {
            //ammoLeft = maxAmmo;
            timeToReload = reloadTime;
            isReloading = false;
            //clipsLeft--;
            var ammoToReload = Mathf.Min(maxAmmo - ammoLeft, clipsLeft);
            clipsLeft -= ammoToReload;
            ammoLeft += ammoToReload;
            

        }

        //one by one reload
        if (timeToReload <= 0 && !hasClips)
        {
            if(ammoLeft != maxAmmo)
            {
                ammoLeft++;
                clipsLeft--;
                source.PlayOneShot(reload);
            }
            else
            {
                isReloading = false;
                source.PlayOneShot(shotgunfinish);
            }
            timeToReload = reloadTime;
            
        }

        shootCooldown -= Time.deltaTime;

        ammoLeftText.text = ammoLeft.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
        clipsAmountText.text = clipsLeft.ToString();
    }

    public void Shoot()
    {
        

        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var offsetX = Random.Range(-spreadAngle, spreadAngle);
        var offsetY = Random.Range(-spreadAngle, spreadAngle);
        bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
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
        onShoot.Invoke();

    }

    public void Reload()
    {
        isReloading = true;
    }
}