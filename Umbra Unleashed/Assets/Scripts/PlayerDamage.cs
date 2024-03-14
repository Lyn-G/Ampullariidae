using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Collider mainCollider; //mainCollider is used for coin collection and enemy attacks
    private bool cooldown = false;

    void Start()
    {
        if (mainCollider == null)
        {
            GetComponent<CapsuleCollider>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //deal damage to player, trigger cooldown
            if (!cooldown)
            {
                //deal damage however

                cooldown = true;
                Invoke("EndCooldown", 0.1f); //end the cooldown after 1/10 of a second
            }
        }
    }

    void EndCooldown()
    {
        cooldown = false;
    }
}
