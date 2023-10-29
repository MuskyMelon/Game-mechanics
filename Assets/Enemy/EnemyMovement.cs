using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public float spaceBetween = 1.5f;
    public float movementSpeed = 0.1f;
    private bool isInRange = false;
    private bool isSpotted = false;
    private bool isShooting = false;
    public bool debugMode = false;

    private NavMeshAgent agent;
    private Gun gun;
   

    private void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if((isInRange && isSpotted) && Vector3.Distance(goal.position, transform.position) >= spaceBetween)
        {
            //Vector3 direction = goal.position - this.transform.position;
            //transform.Translate(direction * movementSpeed * Time.deltaTime);
            agent.destination = goal.position;
        } else
        {
            agent.destination = this.transform.position;
        }
    }

    void FixedUpdate()
    {
        // raycast to see if goal is visible from looking at this object
        Vector3 direction = goal.position - this.transform.position;
        bool isLookingAtPlayer = Vector3.Angle(goal.position - this.transform.position, this.transform.forward) < 15f;
        RaycastHit hit;

        if(isSpotted)
        {
            isInRange = true;
        }

        if(debugMode == true)
        {
            print(isInRange);
            print(isLookingAtPlayer);
            print(isShooting);
        }
       
        // pull trigger if in range and looking at player
        if (isInRange && isLookingAtPlayer && !isShooting)
        {
            isShooting = true;
            gun.pullTrigger();
        }
        else if((!isInRange || !isLookingAtPlayer) && isShooting)
        {
            isShooting = false;
            gun.releaseTrigger();
        }

        if (Physics.Raycast(this.transform.position, direction, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (isSpotted)
                {
                    return;
                }

                isSpotted = true;
            }
            else
            {
                if (!isSpotted)
                {
                    return;
                }

                isSpotted = false;
            }
        }
    }

    public void playerInRage(bool isInRange)
    {
        if(isInRange)
        {
            this.isInRange = true;
        }
    }
}
