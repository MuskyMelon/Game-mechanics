using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Rigidbody body;
    private int floorLayerMask;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        floorLayerMask = LayerMask.GetMask("floor");
    }

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50.0f, floorLayerMask))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
