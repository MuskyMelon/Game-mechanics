using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public GameObject item;

    private GameObject itemClone;

    // Start is called before the first frame update
    void Start()
    {
        itemClone = Instantiate(item, this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        itemClone.transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.transform.tag == "Player"))
        {
            return;
        }

        PlayerPowerupHandler player = other.gameObject.GetComponent<PlayerPowerupHandler>();

        player.SetNewPowerup(item);

        Destroy(this.gameObject);
    }
}
