using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int scene;
    private PlayerStats ScriptReference;

    private void Start()
    {
        ScriptReference = GetComponent<PlayerStats>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
        if(other.tag == "Player")
        {
            ScriptReference.SetMaxHealth();
        }
    }
}
