using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    public Vector3 offset;
    public int ammoCapacity, ammo;
    public float fireRate;
    public float sprayRadius = 0.05f;
    public float reloadTime;
    public float damage = 20;
    public float bulletSpeed = 20;

    private bool mouseDown = false;
    public float timer, reloadTimer = 0;

    public bool isReloading;

    // Update is called once per frame

    private void Start()
    {
        ammo = ammoCapacity;
        timer = 1 / fireRate;
        isReloading = false;
    }

    public void pullTrigger()
    {
        mouseDown = true;
    }

    public void releaseTrigger()
    {
        mouseDown = false;
    }

    private void Update()
    {

        reloadTimer -= Time.deltaTime;

        if (ammo <= 0 && isReloading == false)
        {
            reloadTimer = reloadTime;
            isReloading = true;
        }

        if (reloadTimer > 0)
            return;

        timer -= Time.deltaTime;

        if (isReloading == true)
        {
            isReloading = false;
            ammo = ammoCapacity;
        }

        if (!mouseDown)
            return;

        if (timer <= 0)
        {
            this.Shoot();
            print(ammo);
            ammo -= 1;
            print(ammo);
            timer = 1 / fireRate;
        }

    }

    public void Shoot()
    {
        // find child with tag "Gun"
        Vector3 tempPos = this.transform.position;

        Vector3 rotatedOffset = this.transform.parent.rotation * offset;

        Quaternion tempRotation = transform.parent.rotation;

        tempRotation.y += Random.Range(-sprayRadius, sprayRadius);

        tempPos += rotatedOffset;

        GameObject newBullet = Instantiate(bullet, tempPos, tempRotation);
        Bullet bulletHandler = newBullet.GetComponent<Bullet>();

        bulletHandler.Fire(damage, bulletSpeed);
    }
}
