using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    // 
    public float CoinSpinTorque = 50f;
    private CoinManagerScript coinManagerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // make coin rotate
        this.gameObject.GetComponent<Rigidbody>().AddTorque(CoinSpinTorque * transform.forward);
        coinManagerScript = GameObject.Find("CoinManager").GetComponent<CoinManagerScript>();
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            // release this to the pool
            coinManagerScript.despawn(this.gameObject);
            // player.GetComponent<playerScript>().moneycount++; // This increases the player's coin count when they collide with the coin. I can't access the player script yet! Make sure to uncomment this line!!!
        }
    }
}
