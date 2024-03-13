using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRange : MonoBehaviour
{
    public Collider thisCollider;
    public static List<GameObject> enemiesInRange = new List<GameObject>();

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

    public static void DamageToRange()
    {

    }
}
