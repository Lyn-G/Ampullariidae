using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public Transform player;
    public float CheckFrequency; // Frequency it check if player is near by in seconds
    public float PathfindRadius; // Distance is checks for player
    public Animator animator;

    private NavMeshAgent agent;
    float timePassed; // Measures time passing to see if it should check for enemies
    Rigidbody rb;
    public int state;
    int WALK = 0;
    int IDLE = 1;
    int HIT = 2;
    int HURT = 3;
    GameObject attackHitbox;
    public float knockbackForce;
    public int health;
    public GameObject coinManager;
    public EnemyCountTracker enemyCountManager;
    public List<GameObject> gemList;
    public GameObject hurtparticle;


    // Start is called before the first frame update
    void Start()
    {
        enemyCountManager = GameObject.Find("enemyCountManager").GetComponent<EnemyCountTracker>();
        // https://www.youtube.com/watch?v=u2EQtrdgfNs&ab_channel=CreativeMediaTutorials
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform; // This should always find the player
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0;
        timePassed = 0;
        rb = GetComponent<Rigidbody>();
        state = IDLE;
        attackHitbox = transform.Find("attackHitbox").gameObject;
        transform.forward = new Vector3(0, 0, 0);
        coinManager = GameObject.Find("CoinManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (state != HIT && state != HURT)
        {
            //pathfinding
            float playerX = Mathf.Abs(player.position.x - this.transform.position.x);
            float playerZ = Mathf.Abs(player.position.z - this.transform.position.z);
            // only pathfind to the player if the player is within check distance

            timePassed += Time.deltaTime;
            // Check every 3 seconds for the player while it is idle 
            if (state == IDLE && timePassed > CheckFrequency)
            {

                timePassed = 0;

                if (playerX < PathfindRadius && playerZ < PathfindRadius)
                {

                    state = WALK;
                    Debug.Log(player.position.x - this.transform.position.x);
                    agent.speed = 3.5f;
                }
                else
                {
                    state = IDLE;
                    agent.speed = 0;
                }

            }
            else if (state == WALK && playerX < 2 && playerZ < 2)
            {

                state = HIT;
                //agent.speed = 0;

                StartCoroutine(attack());
                // if the enemy isnt pathfinding they can just do an idle routine
                // dont start the idle routine if its already idle

            } 
            agent.destination = player.position;


            
        }
        animator.SetInteger("state", state);

    }

    void die()
    {
        enemyCountManager.decrement();
        Instantiate(gemList[Random.Range(0, 4)], transform.position, Quaternion.identity); 

        gameObject.SetActive(false);
    }

    IEnumerator attack()
    {
        // i found out how to wait for the animation using chatgpt
        // Wait for the length of the animation
        animator.Play("wind");
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);

        animator.Play("attack");
        attackHitbox.SetActive(true);
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        attackHitbox.SetActive(false);

        animator.Play("end");
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        state = IDLE;
        yield return null;
    }
    IEnumerator hurt( Vector3 hurter)
    {
        // i found out how to wait for the animation using chatgpt
        // Wait for the length of the animation

        // i used chatgpt to find direction vector for hurt force and for particles
        GameObject effect = Instantiate(hurtparticle, transform.position, Quaternion.identity, transform);
        Destroy(effect, 2f);
        Vector3 direction = (transform.position - hurter).normalized;
        // Apply the force in the calculated direction
        rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        animator.Play("takeDammage");
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        state = IDLE;

        yield return null;
    }

    public void outsideHurt(Vector3 hurter, int damage) // call this function from outside of the player and pass the hurter as the arguement in order to make it do its hurt routine
    {

        Debug.Log(health);

        health -= damage;
        if (health < 0)
        {
            die();
        }
        else
        {
            StartCoroutine(hurt(hurter));
        }
    }

}
