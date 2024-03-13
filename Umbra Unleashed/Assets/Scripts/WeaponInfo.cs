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
        if (GetComponent<SpriteRenderer>().sprite != null)
        {
            spriteName = GetComponent<SpriteRenderer>().sprite.name;
        }
        //if there isn't a current weapon equipped, just use your bare hands, but also, add that damn sprite renderer
        else
        {
            spriteName = "bare_hands";
        }
        weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == spriteName);
    }

    //returns weaponData
    public WeaponHandling.WeaponData GetWeaponData()
    {
        return weaponData;
    }

    //takes any sprite name, returns its weapon data
    public static WeaponHandling.WeaponData ChooseWeapon(string weaponSpriteName)
    {
        WeaponHandling.WeaponData newWeaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == weaponSpriteName);
        return newWeaponData;
    }

}
