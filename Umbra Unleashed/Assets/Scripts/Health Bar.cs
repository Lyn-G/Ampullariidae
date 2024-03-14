using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health) {
        slider.value = health;
    }



    void OnTriggerEnter(Collider other)
    {
        // i know how to use on trigger enter, but i forgot the exact syntax and asked chatgpt for an example and learned about
        // this function!
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerController>().takeDammage(transform.position);
            Debug.Log("taking damage");
            //SetDamage(2);

        }
    }
}
