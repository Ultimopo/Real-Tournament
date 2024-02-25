
using UnityEngine;

public class GrenadeMod : MonoBehaviour
{

    public Weapon weapon;
    public GameObject grenade;
    GameObject originalBullet;





    void Awake()
    {
        originalBullet = weapon.bulletPrefab;
    }
    //asign this as event
    public void UnderbarrelGrenadeLauncher()
    {
        if (weapon.ammoLeft != 0)
        {
            weapon.bulletPrefab = grenade;
            weapon.Shoot();
            weapon.bulletPrefab = originalBullet;
        }
    }

}
