using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
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

    private BulletDisplay bulletDisplay;
    public bool isReloading;

    private bool isPlayer = false;

    // Update is called once per frame

    private void Start()
    {
        ammo = ammoCapacity;
        timer = 1 / fireRate;
        isReloading = false;

        bulletDisplay = GameObject.FindGameObjectWithTag("BulletDisplay").GetComponent<BulletDisplay>();

        if(this.gameObject.transform.parent.tag == "Player")
        {
            isPlayer = true;
        }

        UpdateBullets(ammo, ammoCapacity);
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
            UpdateBullets(ammo, ammoCapacity);
        }

        if (!mouseDown)
            return;

        if (timer <= 0)
        {
            this.Shoot();
            ammo -= 1;
            timer = 1 / fireRate;
            UpdateBullets(ammo, ammoCapacity);
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

    private void UpdateBullets(int ammo, int ammoCapacity)
    {
        if (isPlayer)
        {
            bulletDisplay.UpdateBullets(ammo, ammoCapacity);
        }
    }
}
