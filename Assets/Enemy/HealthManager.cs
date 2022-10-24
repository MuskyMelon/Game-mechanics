using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 80f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Bullet bulletScript = other.gameObject.GetComponent<Bullet>();

            health -= bulletScript.getDamage();

            Destroy(other.gameObject);

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
