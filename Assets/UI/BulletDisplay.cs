using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    public GameObject bulletMask;
    public float initialHeight;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // get height of mask
        initialHeight = bulletMask.transform.localScale.y;
        initialPosition = bulletMask.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBullets(int currentBullets, int maxBullets)
    {
        // set height of mask
        float newHeight = initialHeight * ((float)currentBullets / (float)maxBullets);
        bulletMask.transform.localScale = new Vector3(bulletMask.transform.localScale.x, newHeight, bulletMask.transform.localScale.z);

        // lock position of mask to bottom 

        //float newPosition = initialPosition.y + (initialHeight - newHeight) / 2;
        //print(newPosition);
        //bulletMask.transform.localPosition = new Vector3(bulletMask.transform.localPosition.x, newPosition, bulletMask.transform.localPosition.z);
    }
}
