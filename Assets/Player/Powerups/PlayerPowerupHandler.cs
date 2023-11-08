using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupHandler : MonoBehaviour
{
    public GameObject powerupItem;
    private GameObject currentPowerUp;
    private Powerup powerup;

    // Start is called before the first frame update
    void Start()
    {
        if(powerup)
        {
            InitPowerup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            powerup.pullTrigger();

        if (Input.GetMouseButtonUp(1))
            powerup.releaseTrigger();
    }
    
    private void InitPowerup()
    {
        this.SwitchPowerup();
    }

    public void SetNewPowerup(GameObject newPowerUp)
    {
        powerupItem = newPowerUp;
        this.SwitchPowerup();
    }

    private void SwitchPowerup()
    {
        Destroy(currentPowerUp);
        currentPowerUp = Instantiate(powerupItem, this.transform);
        MeshRenderer meshRenderer = currentPowerUp.GetComponent<MeshRenderer>();
        meshRenderer.forceRenderingOff = true;
        powerup = currentPowerUp.GetComponent<Powerup>();

        //gun = currentWeapon.GetComponent<Gun>();
    }
}
