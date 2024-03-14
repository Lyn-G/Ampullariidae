using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{

    //function to be attached to the weapon GameObject that the player has
    //collects the current weapon's WeaponData based on its name - aka - the sprite attached to the gameObject.

    //it will use the name to get the weapon info
    public string spriteName;
    public string weaponType;
    public static WeaponHandling.WeaponData weaponData;

    void Start()
    {
        if(weaponType == "melee")
        {
            Invoke("LoadMeleeWeaponData", 0.001f);
        }
        else if(weaponType == "ranged")
        {
            Invoke("LoadRangeWeaponData", 0.001f);
        }
    }


    public void LoadMeleeWeaponData()
    {
        //separate function for delayed invokation; requires weaponList to already be loaded
        
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite!= null)
        {
            spriteName = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == spriteName);
        }
        
        else
        {
            spriteName = "bare_hands";
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == "bare_hands");
        }
    }

    public void LoadRangeWeaponData()
    {
        //separate function for delayed invokation; requires weaponList to already be loaded
        
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite!= null)
        {
            spriteName = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == spriteName);
        }
        
        else
        {
            spriteName = "bare_hands"; //dude im so tired.
            weaponData = WeaponHandling.weaponList.weapon.Find(weaponEntry => weaponEntry.spriteName == spriteName);
        }
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
