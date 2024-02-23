using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAttack : MonoBehaviour
{
    public GameObject projectile; // public GameObject to select in the inspector
    public Transform spawn; // where projectile spawns
    public float speed = 10; // speed of projectile
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Alpha1)) // key code for 1 on the top of the keyboard
        {
            CastSpell();
        }
    }

    public void CastSpell()
    {
        GameObject spell = Instantiate(projectile); // spawns bullet
        spell.transform.position = spawn.position; // set the spell on the player
        spell.GetComponent<Rigidbody>().velocity = spawn.forward * speed; // set speed of bullet
        
    }
}
