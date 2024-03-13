using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public TMP_Text healthText;
    public Slider slider;
    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text strengthText;
    public TMP_Text dexterityText;
    public TMP_Text intelligenceText;
    public TMP_Text charismaText;
    public TMP_Text weaponNameText;
    public TMP_Text weaponPowerText;
    public TMP_Text weaponRangeText;

    // Add other stats and attributes here
    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int attack;
    public int defense;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int charisma;

    // Selected Weapon Icons and Skill Icons
    public Image weaponIcon;
    public Image skillIcon1;
    public Image skillIcon2;
    public Sprite emptySlotSprite; 

    // Weapon Icons
    //Staffs
    [SerializeField] private Sprite sprigganScepterSprite;
    [SerializeField] private Sprite tuningRodSprite;
    [SerializeField] private Sprite occultStaffSprite;
    [SerializeField] private Sprite monksStaffSprite;
    //Fists
    [SerializeField] private Sprite fistsOfFurySprite;
    [SerializeField] private Sprite brassKnucklesSprite;
    [SerializeField] private Sprite powerGloveSprite;

    //Skill Icons
    
    //Staffs
    //tuningRod
    [SerializeField] private Sprite posionCloudSprite;
    [SerializeField] private Sprite rockThrowSprite;

    //sprigganScepter
    [SerializeField] private Sprite vineChokeSprite;
    [SerializeField] private Sprite magicArcSprite;

    //occultStaff
    [SerializeField] private Sprite summonSkeletonSprite;
    [SerializeField] private Sprite corruptionSprite;

    //monksStaff
    [SerializeField] private Sprite kiExtractionSprite;
    [SerializeField] private Sprite squallOfFistsSprite;

    //Fists
    //fistsOfFury
    [SerializeField] private Sprite hiddenBladeSprite;
    [SerializeField] private Sprite flyingKickSprite;

    //brassKnuckles
    [SerializeField] private Sprite hammerFistSprite;
    [SerializeField] private Sprite UppercutSprite;
    
    //powerGlove
    [SerializeField] private Sprite chargePunchSprite;
    [SerializeField] private Sprite launchSprite;

    private void Start()
    {
        healthText.text = "Health: " + health.ToString()+ "/" + maxHealth.ToString();
        manaText.text = "Mana: " + mana.ToString()+ "/" + maxMana.ToString();
        attackText.text = "Attack: " + attack.ToString();
        defenseText.text = "Defense: " + defense.ToString();
        strengthText.text = "Strength: " + strength.ToString();
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        charismaText.text = "Charisma: " + charisma.ToString();
        // Update Weapon Stat UI
        weaponNameText.text = "";
        weaponPowerText.text = "";
        weaponRangeText.text = "";
        // Update Weapon and Skill Icon UI
        weaponIcon.sprite = emptySlotSprite;
        skillIcon1.sprite = emptySlotSprite;
        skillIcon2.sprite = emptySlotSprite;
    }   

    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.text = "Health: " + health.ToString();
        // Update UI
    }

    public void ChangeMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        manaText.text = "Mana: " + mana.ToString();
        // Update UI
    }

    public void ChangeAttack(int amount)
    {
        attack += amount;
        attackText.text = "Attack: " + attack.ToString();
        // Update UI
    }

    public void ChangeDefense(int amount)
    {
        defense += amount;
        defenseText.text = "Defense: " + defense.ToString();
        // Update UI
    }

    public void ChangeStrength(int amount)
    {
        strength += amount;
        strengthText.text = "Strength: " + strength.ToString();
        // Update UI
    }

    public void ChangeDexterity(int amount)
    {
        dexterity += amount;
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        // Update UI
    }

    public void ChangeIntelligence(int amount)
    {
        intelligence += amount;
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        // Update UI
    }

    public void ChangeCharisma(int amount)
    {
        charisma += amount;
        charismaText.text = "Charisma: " + charisma.ToString();
        // Update UI
    }

    public void SelectingWeapon(string weaponName)
    {
        var weaponData = WeaponHandling.GetWeaponDataByName(weaponName);
        if(weaponData == null)
        {
            Debug.Log("SelectingWeapon: Weapon Data is null");
            return;
        }
        weaponNameText.text = weaponData.name;
        weaponPowerText.text = weaponData.minPower.ToString() + " - " + weaponData.maxPower.ToString();
        weaponRangeText.text = weaponData.range;
        Debug.Log("Updating Weapon Icons...");
        Debug.Log("Selected Weapon: " + weaponData.name);
        Debug.Log("Skills: " + weaponData.skill1 + " and " + weaponData.skill2);
        //Updating Weapon Icon
        switch(weaponData.name)
    {   
        //Staffs
        case "Spriggan Scepter":
            weaponIcon.sprite = sprigganScepterSprite;
            skillIcon1.sprite = vineChokeSprite;
            skillIcon2.sprite = magicArcSprite;
            break;
        case "Tuning Rod":
            weaponIcon.sprite = tuningRodSprite;
            skillIcon1.sprite = posionCloudSprite;
            skillIcon2.sprite = rockThrowSprite;
            break;
        case "Occult Staff":
            weaponIcon.sprite = occultStaffSprite;
            skillIcon1.sprite = summonSkeletonSprite;
            skillIcon2.sprite = corruptionSprite;
            break;
        case "Monk's Staff":
            weaponIcon.sprite = monksStaffSprite;
            skillIcon1.sprite = kiExtractionSprite;
            skillIcon2.sprite = squallOfFistsSprite;
            break;    
        //Fists
        case "Fists of Fury":
            weaponIcon.sprite = fistsOfFurySprite;
            skillIcon1.sprite = hiddenBladeSprite;
            skillIcon2.sprite = flyingKickSprite;
            break;
        case "Brass Knuckles":
            weaponIcon.sprite = brassKnucklesSprite;
            skillIcon1.sprite = hammerFistSprite;
            skillIcon2.sprite = UppercutSprite;
            break;
        case "Power Glove":
            weaponIcon.sprite = powerGloveSprite;
            skillIcon1.sprite = chargePunchSprite;
            skillIcon2.sprite = launchSprite;
            break;
        // ... and so on for each weapon ...
    }
        
    }

    public void DeselectingWeapon()
    {
        weaponNameText.text = "";
        weaponPowerText.text = "";
        weaponRangeText.text = "";

        //Updating Weapon Icon
        weaponIcon.sprite = emptySlotSprite;
        //Updating Skill Icons
        skillIcon1.sprite = emptySlotSprite;
        skillIcon2.sprite = emptySlotSprite;
    }

    public int GetStatValue(string statName)
    {
        switch (statName)
        {
            case "Health":
                return health;
            case "Mana":
                return mana;
            case "Attack":
                return attack;
            case "Defense":
                return defense;
            case "Strength":
                return strength;
            case "Dexterity":
                return dexterity;
            case "Intelligence":
                return intelligence;
            case "Charisma":
                return charisma;
            default:
                return 0;
        }
    }
}
