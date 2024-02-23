using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.forward * speed *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
