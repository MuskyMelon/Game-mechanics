using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    float textureOffset = 1f;
    public GameObject bullet;
    int ammo = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ammo; i++) {
            //Instantiate(bullet, )
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
