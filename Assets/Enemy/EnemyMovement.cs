using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public float spaceBetween = 1.5f;
    public float movementSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(goal.position, transform.position) >= spaceBetween)
        {
            Vector3 direction = goal.position - this.transform.position;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
       
    }
}
