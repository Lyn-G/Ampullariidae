using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{

    public HealthBar healthBar;
    public int currentHealth;
    public int maxHealth = 20;
    public GameObject playerhurtparticle;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar) healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public int DealDamage(int amount) {
        currentHealth -= amount;
        if (healthBar) healthBar.SetHealth(currentHealth);
        return currentHealth;
    }
}
