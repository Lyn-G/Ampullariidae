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
    }
}

