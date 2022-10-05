using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    public Vector3 offset;

    // Update is called once per frame
    public void Shoot()
    {
        Vector3 tempPos = this.transform.parent.transform.GetChild(0).position;

        Vector3 rotatedOffset = this.transform.parent.rotation * offset;

        Quaternion tempRotation = transform.parent.rotation;

        tempPos += rotatedOffset;

        GameObject newBullet = Instantiate(bullet, tempPos, tempRotation);
        Bullet bulletHandler = newBullet.GetComponent<Bullet>();

        bulletHandler.Fire();
    }
}
