using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health;
    public float maxHealth = 80f;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
    }

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

            updateHealthBar();
        }
    }


    private void updateHealthBar()
    {
        slider.value = health / maxHealth;
    }
}
