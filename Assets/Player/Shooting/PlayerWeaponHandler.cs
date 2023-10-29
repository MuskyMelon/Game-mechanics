using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public GameObject weapon;
    private GameObject currentWeapon;
    private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gun.pullTrigger();

        if (Input.GetMouseButtonUp(0))
            gun.releaseTrigger();
    }
    
    private void initWeapon()
    {
        this.switchWeapon();
    }

    public void setNewWeapon(GameObject newWeapon)
    {
        weapon = newWeapon;
        this.switchWeapon();
    }

    private void switchWeapon()
    {
        print(weapon);
        Destroy(currentWeapon);
        currentWeapon = Instantiate(weapon, this.transform);
        gun = currentWeapon.GetComponent<Gun>();
    }
}
