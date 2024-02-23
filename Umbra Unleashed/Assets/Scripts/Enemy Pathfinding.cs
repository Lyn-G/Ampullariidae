using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        // https://www.youtube.com/watch?v=u2EQtrdgfNs&ab_channel=CreativeMediaTutorials
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            GameObject.Find("EnemyManager").GetComponent<enemyManagerScript>().despawn(this.gameObject);
        }
    }
}
