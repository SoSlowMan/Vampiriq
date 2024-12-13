using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public Transform firePoint;

    public float timeBetweenShots;
    public float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (isFiring)
        {
            if (shotCounter < timeBetweenShots)
            {
                shotCounter = 2 * timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.Coloring();
                newBullet.speed = bulletSpeed;
            }
        }
        if (shotCounter <= -1000f)
        {
            shotCounter = 0;
        }
    }
}
