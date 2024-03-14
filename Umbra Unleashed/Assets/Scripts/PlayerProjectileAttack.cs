using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectileAttack : MonoBehaviour
{
    public GameObject projectile; // public GameObject to select in the inspector
    // public Transform spawn; // where projectile spawns
    public float speed = 10; // speed of projectile
    public float coolDown; // this is how long the cool down is
    float coolDownStatus; // this is how long the cooldown 
    string playerDirection;
    
    //[SerializeField] private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coolDownStatus -= Time.deltaTime;
       if(Input.GetKeyDown(KeyCode.Alpha1)) // key code for 1 on the top of the keyboard
        {
            Debug.Log("1 is being pressed.");
            CastSpell();
        }

        if (Input.GetKeyDown(KeyCode.W)) // key code for 1 on the top of the keyboard
        {
            playerDirection = "forward";
        } else if (Input.GetKeyDown(KeyCode.A)) // key code for 1 on the top of the keyboard
        {
            playerDirection = "left";
        } else if (Input.GetKeyDown(KeyCode.S)) // key code for 1 on the top of the keyboard
        {
            playerDirection = "back";
        } else if (Input.GetKeyDown(KeyCode.D)) // key code for 1 on the top of the keyboard
        {
            playerDirection = "right";
        }
    }



    public void CastSpell()
    {// this is some of the ugliest code ever but it is last minute! and its getting the job done!
        if (coolDownStatus > 0) return;
        Vector3 bulletDirection = Vector3.forward;
        if (playerDirection == "forward")
        {
            bulletDirection = Vector3.forward;
        } else if (playerDirection == "back")
        {
            bulletDirection = Vector3.forward * -1f;
        } else if (playerDirection == "right")
        {
            bulletDirection = Vector3.right;
        } else if (playerDirection == "left")
        {
            bulletDirection = Vector3.right  * -1f;
        }

        GameObject spell = Instantiate(projectile, transform.position, Quaternion.Euler(bulletDirection)); // spawns bullet
        spell.GetComponent<Bullet>().dammage = 10;
        // spell.transform.position = spawn.position; // set the spell on the player
        Rigidbody spellCast = spell.GetComponent<Rigidbody>();
        if (spellCast != null)
        {
            spellCast.velocity = bulletDirection * speed;
            Destroy(spell, 2f);
        }
        coolDownStatus = coolDown;
    }
}
