using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dammage;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
        //transform.Translate(transform.forward * speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<bossScript>().outsideHurt(transform.position, dammage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
            
        {
            other.gameObject.GetComponent<EnemyPathfinding>().outsideHurt(transform.position, dammage);
            Destroy(this.gameObject);
        }
        
    }
}
