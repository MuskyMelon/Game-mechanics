using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        this.gameObject.GetComponent<Canvas>().worldCamera = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // look at the main camera 
        this.transform.LookAt(mainCamera.transform);
    }
}
