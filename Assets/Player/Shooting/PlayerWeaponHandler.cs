using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public GameObject weapon;
    private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = weapon.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gun.Shoot();

    }
}
