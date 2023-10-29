using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerProximityCheck : MonoBehaviour
{

    // list of enemuies
    public List<GameObject> disabledEnemies = new List<GameObject>();
    public GameObject player;

    [SerializeField]
    private float distance = 12f;

    // Start is called before the first frame update
    void Start()
    { 
        // select all enemies that are children of this
        foreach (Transform child in transform)
        {
            disabledEnemies.Add(child.gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void FixedUpdate()
    {
        for(int i = disabledEnemies.Count - 1; i >= 0; i--)
        {
            if (disabledEnemies[i] == null)
            {
                disabledEnemies.Remove(disabledEnemies[i]);
                continue;
            }
            if (Vector3.Distance(disabledEnemies[i].transform.position, player.transform.position) < distance)
            {
                disabledEnemies[i].GetComponent<EnemyMovement>().playerInRage(true);
                // remove from list
                disabledEnemies.Remove(disabledEnemies[i]);
            }
        }

    }
}
