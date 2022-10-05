using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 20;
    public bool fired = false;
    public float movementSpeed;

    // Update is called once per frame
    public void Fire()
    {
        fired = true;
    }

    private void FixedUpdate()
    {
        if (fired == true)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }

    public float getDamage()
    {
        return damage;
    }
}
