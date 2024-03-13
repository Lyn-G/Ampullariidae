using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAttack : MonoBehaviour
{
    public GameObject projectile; // public GameObject to select in the inspector
    // public Transform spawn; // where projectile spawns
    public float speed = 10; // speed of projectile

    [SerializeField] private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Alpha1)) // key code for 1 on the top of the keyboard
        {
            Debug.Log("1 is being pressed.");
            CastSpell();
            cooldown.StartCooldown();
        }
    }

    public void CastSpell()
    {
        if (cooldown.isCoolingDown) return;
        GameObject spell = Instantiate(projectile, transform.position, transform.rotation); // spawns bullet
        // spell.transform.position = spawn.position; // set the spell on the player
        Rigidbody spellCast = spell.GetComponent<Rigidbody>();
        if (spellCast != null)
        {
            spellCast.velocity = transform.forward * speed;
            Destroy(spell, 2f);
        }
        
    }
}
