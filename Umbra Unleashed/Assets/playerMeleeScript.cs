using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMeleeScript : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter(Collider other)
    {
        // i know how to use on trigger enter, but i forgot the exact syntax and asked chatgpt for an example and learned about
        // this function!
        if (other.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<bossScript>().outsideHurt(transform.position, damage);
        }
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyPathfinding>().outsideHurt(transform.position, damage);
        }
    }
}
