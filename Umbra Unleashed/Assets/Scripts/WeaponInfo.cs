using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{

    //function to be attached to the weapon GameObject that the player has
    //collects the current weapon's WeaponData based on its name - aka - the sprite attached to the gameObject.

    //it will use the name to get the weapon info
    public string spriteName;
    public static WeaponHandling.WeaponData weaponData;

    void Start()
    {
        Invoke("LoadWeaponData", 0.001f);
    }

    public void LoadWeaponData()
    {
        //separate function for delayed invokation; requires weaponList to already be loaded
        if (this.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            spriteName = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == spriteName);
            Debug.Log("WeaponData loaded: " + weaponData.spriteName+ " flavor text: " + weaponData.flavorText);
        }
        //if there isn't a current weapon equipped, just use your bare hands, but also, add that damn sprite renderer
        else
        {
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == "bare_hands");
            this.gameObject.AddComponent<SpriteRenderer>().sprite.name = "bare_hands"; //TEMP: CHANGE LATER
        }
    }

    //returns weaponData
    public WeaponHandling.WeaponData GetWeaponData()
    {
        return weaponData;
    }

}
