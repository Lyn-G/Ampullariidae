using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player movement values
    public float speed = 20.0f; // Adjust the speed of the player movement
    private float moveHorizontal; //also used for animations
    private float moveVertical; //also used for animations

    //player components
    public Rigidbody rb; // Reference to the Rigidbody component
    public Animation anim; //reference to the animation component
    public Animator animator; //reference to the animator component
    public SpriteRenderer playerSprite; //player sprite
    public PlayerStats statsManager; //player stats

    //weapon info
    public WeaponHandling.WeaponData currentRangeWeapon; //stores the current range weapon that the player is holding's data, to account for what animation/attack is used.
    public WeaponHandling.WeaponData currentMeleeWeapon; //stores the current melee weapon that the player is holding's data, to account for what animation/attack is used.
    public GameObject rangeWeapon; //the actual range weapon game object with the sprite renderer on it
    public GameObject meleeWeapon; //the actual melee weapon game object with the sprite renderer on it

    //ranges
    public GameObject shortRange;
    public GameObject mediumRange;
    public GameObject longRange;

    //for animations
    private bool sideFacing = false;
    private bool flipped = false;
    private int attacking; //0 is no attack; 1 is punch; 2 is uppercut
    //it is way too much of a hassle to have a bunch of individual bools for EVERY ATTACK.

    void Start()
    {
        GameObject playerBody = transform.GetChild(0).gameObject;
        // Get the Rigidbody, Animation, SpriteRenderer component from the player game object
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (anim == null)
        {
            anim = playerBody.GetComponent<Animation>();
        }
        if (animator == null)
        {
            animator = playerBody.GetComponent<Animator>();
        }
        if (playerSprite == null)
        {
            playerSprite = playerBody.GetComponent<SpriteRenderer>();
        }

        //Get weapon information; if there is no weapon equipped, currentWeapon will default to "Bare Hands"
        //delayed to make sure things load in the proper order
        Invoke("LoadRangeWeaponData", 0.005f);
        Invoke("LoadMeleeWeaponData", 0.005f);

        StartCoroutine(InputCheck());
    }

    void Update()
    {
        // Handle player movement
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //animations
        CheckDirection();
        animator.SetFloat("moveVertical", moveVertical);
        animator.SetFloat("sideSpeed", Mathf.Abs(moveHorizontal));
        animator.SetBool("sideFacing", sideFacing);
        animator.SetInteger("attacking", attacking);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Check if the path is clear && there is not a current animation before moving
        if (IsPathClear(movement) && attacking == 0)
        {
            rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            FlipSprite(moveHorizontal);
        }
    }

    //runs every 0.01s, checks to see if attack keys were entered
    IEnumerator InputCheck()
    {
        while (true)
        {
            if(attacking == 0)
            {
                //attacking determines animation: 0 is no attack; 1 is punch; 2 is uppercut, 3 is thrust; 4 is slash; 5 is hand thrust.
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    //melee weapon attack - either Sword or Fists
                    //attack 1 should be a punch for Fists
                    //          and a thrust for Sword
                    if (currentMeleeWeapon.type == "Fists")
                    {
                        attacking = 1;
                        shortRange.GetComponent<CombatRange>().DamageToRange(currentMeleeWeapon.minPower, currentMeleeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.83f);
                    }
                    else if (currentMeleeWeapon.type == "Sword")
                    {
                        attacking = 3;
                        mediumRange.GetComponent<CombatRange>().DamageToRange(currentMeleeWeapon.minPower, currentMeleeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.83f);
                    }

                    //after 0.83s, end attack animation
                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    //melee weapon attack - either Sword or Fists
                    //attack 1 should be an uppercut for Fists
                    //          and a slash for Sword
                    if (currentMeleeWeapon.type == "Fists")
                    {
                        shortRange.GetComponent<CombatRange>().DamageToRange(currentMeleeWeapon.minPower, currentMeleeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.83f);
                        attacking = 2;
                    }
                    else if (currentMeleeWeapon.type == "Sword")
                    {
                        mediumRange.GetComponent<CombatRange>().DamageToRange(currentMeleeWeapon.minPower, currentMeleeWeapon.maxPower, statsManager.attack);
                        attacking = 4;
                        Invoke("AttackEnd", 0.83f);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    //ranged weapon attack - either Tome or Staff
                    if(currentRangeWeapon.type == "Tome")
                    {
                        attacking = 5;
                        mediumRange.GetComponent<CombatRange>().DamageToRange(currentRangeWeapon.minPower, currentRangeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.67f);
                    }
                    else if (currentRangeWeapon.type == "Staff")
                    {
                        attacking = 5;
                        longRange.GetComponent<CombatRange>().DamageToRange(currentRangeWeapon.minPower, currentRangeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.67f);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    //ranged weapon attack - either Tome or Staff
                    if (currentRangeWeapon.type == "Tome")
                    {
                        attacking = 5;
                        longRange.GetComponent<CombatRange>().DamageToRange(currentRangeWeapon.minPower, currentRangeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.67f);
                    }
                    else if (currentRangeWeapon.type == "Staff")
                    {
                        attacking = 5;
                        longRange.GetComponent<CombatRange>().DamageToRange(currentRangeWeapon.minPower, currentRangeWeapon.maxPower, statsManager.attack);
                        Invoke("AttackEnd", 0.67f);
                    }
                }
            }
            
            yield return new WaitForSeconds(0.001f);
        }
    }

    private void AttackEnd()
    {
        attacking = 0;
    }

    public void LoadRangeWeaponData()
    {
        currentRangeWeapon = rangeWeapon.GetComponent<WeaponInfo>().GetWeaponData();
    }

    public void LoadMeleeWeaponData()
    {
        currentMeleeWeapon = meleeWeapon.GetComponent<WeaponInfo>().GetWeaponData();
    }

    bool IsPathClear(Vector3 direction)
    {
        float distanceToCheck = 1.0f; // Adjust based on your needs
        RaycastHit hit;

        // Perform a raycast in the direction of movement to detect terrain or obstacles
        if (Physics.Raycast(transform.position, direction, out hit, distanceToCheck))
        {
            if (hit.collider.tag == "Terrain")
            {
                // Terrain was hit, movement in this direction is blocked
                //Debug.Log("Terrain detected");
                return false;
            }
        }

        // No terrain or obstacles detected in the path, movement is allowed
        return true;
    }

    void FlipSprite(float moveHorizontal)
    {
        // If moving right and the sprite is facing left, flip the sprite by adjusting its localScale
        if (moveHorizontal > 0 && !flipped)
        {
            playerSprite.flipX = true;
            flipped = !flipped;
        }
        // If moving left and the sprite is facing right, flip the sprite to face left
        else if (moveHorizontal < 0 && flipped)
        {
            playerSprite.flipX = false;
            flipped = !flipped;
        }
        // If not moving horizontally, no need to flip the sprite
    }

    //get which direction the player is facing, use for animations
    private void CheckDirection()
    {
        if(moveVertical != 0)
        {
            sideFacing = false;
        }
        else if (moveHorizontal != 0)
        {
            sideFacing = true;
        }
    }
}
