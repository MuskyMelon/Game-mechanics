using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlocking : MonoBehaviour
{

    GameObject[] AI;
    public float spaceBetween = 1.5f;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("Enemy");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        this.checkForEmpty();
        foreach (GameObject go in AI)
        {
          
            if(go == gameObject)
                continue;

            float distance = Vector3.Distance(go.transform.position, this.transform.position);
            if (distance <= spaceBetween)
            {
                Vector3 direction = transform.position - go.transform.position;
                agent.destination = direction * Time.deltaTime;
            }
        }
    }

    private void checkForEmpty()
    {
        for (int i = 0; i < AI.Length; i++)
        {
            if (AI[i] == null)
            {
                this.Start();
                return;
            }
        }
    }
}
