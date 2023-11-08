using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health;
    public float maxHealth = 80f;
    public Slider slider;
    public bool isImmuneToBullets = false;
    public bool showHealthbar = true;

    public ScreenHandler screenHandler;
    

    void Start()
    {
        health = maxHealth;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && !isImmuneToBullets)
        {
            Bullet bulletScript = other.gameObject.GetComponent<Bullet>();

            health -= bulletScript.getDamage();

            Destroy(other.gameObject);
        }

        print(other.gameObject.tag);

        if (other.gameObject.tag == "iceBullet")
        {
            print("owo");
            Bullet bulletScript = other.gameObject.GetComponent<Bullet>();

            health -= bulletScript.getDamage();
            Destroy(other.gameObject);
        }

        if (health <= 0)
        {
            if (gameObject.tag == "Player")
            {
                screenHandler.ShowLoseScreen();
            }
            Destroy(this.gameObject);
        }

        updateHealthBar();
    }


    private void updateHealthBar()
    {
        if(showHealthbar)
            slider.value = health / maxHealth;
    }
}
