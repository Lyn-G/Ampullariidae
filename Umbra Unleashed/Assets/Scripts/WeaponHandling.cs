using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponHandling : MonoBehaviour
{

    public TextAsset jsonData;

    [System.Serializable]
    public class WeaponData
    {
        public string type;
        public string spriteName;
        public string name;
        public int minPower;
        public int maxPower;
        public string range;
        public string skill1;
        public string skill2;
        public string skill3;
        public string flavorText;
    }

    [System.Serializable]
    public class WeaponList
    {
        public List<WeaponData> weapon;
    }

    public static WeaponList weaponList = new WeaponList();

    // Start is called before the first frame update
    void Start()
    {
        weaponList = JsonUtility.FromJson<WeaponList>(jsonData.text);
        //foreach (var weapon in weaponList.weapon)
        //{
        //}    Debug.Log("Loaded weapon: " + weapon.name);
        //}
    }


    public static WeaponData GetWeaponDataByName(string weaponName)
    {
        //using sprite name, not actual name
        return weaponList.weapon.Find(weapon => weapon.name == weaponName);
    }

    public static WeaponData GetWeaponDataBySpriteName(string weaponSpriteName)
    {
        //using sprite name, not actual name
        return weaponList.weapon.Find(weapon => weapon.spriteName == weaponSpriteName);
    }

}

