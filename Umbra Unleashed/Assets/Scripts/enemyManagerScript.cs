using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


// This script can be used for multiple enemies of different types, just apply it to the manager!! and add the respective prefabs 
public class enemyManagerScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Pointer to enemy prefab
    public GameObject enemyManager;

    public GameObject coinManager;


    public IObjectPool<GameObject> enemyPool; // pointer to enemy pool
    Vector3 spawnLocation;
    int ActiveEnemyCounter;


    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = Vector3.zero;
        ActiveEnemyCounter = 0;


        // make the pool
        // pulled this from my (James') module 1, which used this video
        // https://www.youtube.com/watch?v=7EZ2F-TzHYw&ab_channel=Tarodev


        enemyPool = new ObjectPool<GameObject>(() =>
        { 
            // This is how the pool objects are added to the pool ( instantiated)
            return Instantiate(enemyPrefab, spawnLocation, Quaternion.identity, enemyManager.transform);
        }, enemy =>
        { 
            // This is the get function!
            if (enemy.activeInHierarchy == true)
            {
                enemy.SetActive(false);
            }
            enemy.transform.position  = new Vector3 (0, 0, 0);
            enemy.SetActive(true);
            ActiveEnemyCounter++;
        }, enemy=> 
        {
            // This is the release function
            enemy.SetActive(false);
            ActiveEnemyCounter--;

        }, enemy=>
        {
            // this is what happens when the pool is full and needs to remove an enemy
            Destroy(enemy.gameObject);
        }, false, 15, 30 // the false optimizes this (idk how), 15 is the ammount it instantiates at the beginning and 30 is the most that will ever spawn
        );

    }

    public void spawn(Vector3 enemyLocation) // Other scripts can call this, saying please spawn this enemy here
    {
        spawnLocation = enemyLocation;
        enemyPool.Get();

    }
    public void despawn(GameObject enemy) // Other scripts can call this and say please despawn this enemy
    {
        coinManager.GetComponent<CoinManagerScript>().spawn(enemy.transform.position);
        enemyPool.Release(enemy);

        
    }
    

}
