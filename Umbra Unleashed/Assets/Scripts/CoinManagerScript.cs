using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinManagerScript : MonoBehaviour
{
    public GameObject coinPrefab;           // Pointer to enemy prefab
    public GameObject coinManager;         // Pointer to the coin manager
    public float coinPropell;               // The force to propell the coins when the spawn
    public IObjectPool<GameObject> CoinPool; // pointer to enemy pool
    Vector3 spawnLocation;
    int ActiveCoinCounter;


    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = Vector3.zero;
        ActiveCoinCounter = 0;


        // make the pool
        // pulled this from my (James') module 1, which used this video
        // https://www.youtube.com/watch?v=7EZ2F-TzHYw&ab_channel=Tarodev


        CoinPool = new ObjectPool<GameObject>(() =>
        {
            // This is how the pool objects are added to the pool ( instantiated)
            return Instantiate(coinPrefab, spawnLocation, Quaternion.Euler(90, 0, 0), coinManager.transform);
        }, coin =>
        {
            // This is the get function!
            if (coin.activeInHierarchy == true)
            {
                coin.SetActive(false);
            }
            coin.transform.position = spawnLocation;
            coin.SetActive(true);
            // coin.GetComponent<Rigidbody>().AddForce(Random.Range(-5f, 5f), Random.Range(20f, 100f), Random.Range(-5f, 5f)); // trying to make coin bounce when it spawns
            ActiveCoinCounter++;

        }, coin =>
        {
            // This is the release function
            coin.SetActive(false);
            ActiveCoinCounter--;

        }, coin =>
        {
            // this is what happens when the pool is full and needs to remove an coin
            Destroy(coin.gameObject);
        }, false, 30, 50 // the false optimizes this (idk how), 15 is the ammount it instantiates at the beginning and 30 is the most that will ever spawn
        );

    }

    public void spawn(Vector3 coinLocation) // Other scripts can call this, saying spawn this coin here
    {
        spawnLocation = coinLocation;
        CoinPool.Get();

    }
    public void despawn(GameObject coin) // Other scripts can call this and say despawn this coin
    {
        CoinPool.Release(coin);

        // Add a coin where the coin died
    }


}
