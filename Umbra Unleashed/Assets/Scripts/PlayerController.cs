using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed of the player movement
    public Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 defaultScale; // To store the original scale of the player
    public WeaponHandling.WeaponData currentWeapon; //stores the current weapon that the player is holding, to account for what animation/attack is used.


    void Start()
    {
        // Get the Rigidbody component from the player game object
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        // Store the original local scale of the player
        defaultScale = transform.localScale;

        //Get weapon information; if there is no weapon equipped, currentWeapon will default to "Bare Hands"
        //delayed to make sure things load in the proper order
        Invoke("LoadWeaponData", 0.005f);

        StartCoroutine(InputCheck());
    }

    void Update()
    {
        // Handle player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Check if the path is clear before moving
        if (IsPathClear(movement))
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
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Using attack: " + currentWeapon.skill1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Using attack: " + currentWeapon.skill2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Using attack: " + currentWeapon.skill3);
            }
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    private void LoadWeaponData()
    {
        currentWeapon = transform.Find("Weapon").GetComponent<WeaponInfo>().GetWeaponData();
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
                return false;
            }
        }

        // No terrain or obstacles detected in the path, movement is allowed
        return true;
    }

    void FlipSprite(float moveHorizontal)
    {
        // If moving right and the sprite is facing left, flip the sprite by adjusting its localScale
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(defaultScale.x), defaultScale.y, defaultScale.z);
        }
        // If moving left and the sprite is facing right, flip the sprite to face left
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(defaultScale.x), defaultScale.y, defaultScale.z);
        }
        // If not moving horizontally, no need to flip the sprite
    }
}
