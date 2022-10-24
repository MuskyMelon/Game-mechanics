using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    public bool fired = false;
    private float speed;

    // Update is called once per frame
    public void Fire(float newDamage, float newSpeed)
    {
        fired = true;
        damage = newDamage;
        speed = newSpeed;     
    }

    private void FixedUpdate()
    {
        if (fired == true)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    public float getDamage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
