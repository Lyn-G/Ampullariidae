using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatRange : MonoBehaviour
{
    public Collider thisCollider;
    public List<GameObject> enemiesInRange = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(thisCollider == null)
        {
            thisCollider = GetComponent<BoxCollider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && (enemiesInRange.Find(x => other.gameObject) == null))
        {
            //add to enemiesInRange list
            enemiesInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && (enemiesInRange.Find(x => other.gameObject) != null))
        {
            //remove from enemiesInRange list
            enemiesInRange.Remove(other.gameObject);
        }
    }

    public void DamageToRange(int minPower, int maxPower, float duration)
    {
        if(enemiesInRange.Count > 0)
        {
            //screenshake!
            GameObject.Find("Camera").GetComponent<PlayerMovement>().CauseScreenShake(duration);
        }

        //pass in the current weapon's minPower, maxPower, and the stats manager's attack variable
        for(int i=0; i < enemiesInRange.Count; i++)
{
    GameObject enemy = enemiesInRange[i];
    int damageToDeal = Random.Range(minPower, maxPower+1);

    attackScript enemyInfo = enemy.GetComponent<attackScript>();
    int enemyHealth = enemyInfo.DealDamage(damageToDeal);
    if(enemyHealth <= 0)
    {
        enemiesInRange.Remove(enemy);
        Destroy(enemy);
        i--;
    }
}
    }
}