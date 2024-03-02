using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public Transform player;
    public float CheckFrequency; // Frequency it check if player is near by in seconds
    public float PathfindRadius; // Distance is checks for player

    private NavMeshAgent agent;
    float timePassed; // Measures time passing to see if it should check for enemies
    bool idle = false; // Is the player currently idle
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        // https://www.youtube.com/watch?v=u2EQtrdgfNs&ab_channel=CreativeMediaTutorials
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        timePassed = 0;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        // Check every 3 seconds
        if ( timePassed > CheckFrequency) {
            timePassed = 0;

            // only pathfind to the player if the player is within check distance
            if ((Mathf.Abs(player.position.x - this.transform.position.x) < PathfindRadius) && (Mathf.Abs(player.position.y - this.transform.position.y) < PathfindRadius))
            {
                Debug.Log(player.position.x - this.transform.position.x);
                idle = false;
                agent.speed = 3.5f;
            }
            else
            {
                agent.speed = 0;
                // if the enemy isnt pathfinding they can just do an idle routine
                // dont start the idle routine if its already idle
                if (!idle )
                {

                    idle = true;
                    StartCoroutine(Idle());
                }
                
            }
        }
        agent.destination = player.position;
        

        if ( Input.GetKeyDown(KeyCode.Space) ) {
            GameObject.Find("EnemyManager").GetComponent<enemyManagerScript>().despawn(this.gameObject);
        }
    }


    IEnumerator Idle()
    {
        /*
        yield return new WaitForSeconds(Random.Range(1, 5)); // It will wait before starting the idle activity

        while (idle == true && rb != null)
        {
            rb.AddTorque(Vector3.right * Random.Range(-20, 20)); // Turn a random ammount
            yield return new WaitForSeconds(1f); // wait for it to finish rotating
            rb.AddForce(Vector3.forward * Random.Range(-20, 20)); // Turn a random ammount
            yield return new WaitForSeconds(Random.Range(1, 5)); // It will walk in a random direction for 1-5 seconds
        }
        */
        yield return null;
    }
}
