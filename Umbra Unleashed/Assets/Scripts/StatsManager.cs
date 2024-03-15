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

    //Blades
    [SerializeField] private Sprite cutlassSprite;
    [SerializeField] private Sprite busterSwordSprite;
    [SerializeField] private Sprite woodenSwordSprite;
    [SerializeField] private Sprite sacrificialDaggerSprite;

    //Tomes
    [SerializeField] private Sprite decayedDictionarySprite;
    [SerializeField] private Sprite diviningGuideSprite;
    [SerializeField] private Sprite librariansLedgerSprite;
    [SerializeField] private Sprite planisphereSprite;
    

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

    //Blades
    //cutlass
    [SerializeField] private Sprite swabTheDeckSprite;
    [SerializeField] private Sprite boardingPartySprite;
    //busterSword
    [SerializeField] private Sprite HeaveSprite;
    [SerializeField] private Sprite MomemtumSprite;
    //woodenSword
    [SerializeField] private Sprite thrustSprite;
    [SerializeField] private Sprite SpinSprite;
    //sacrificialDagger
    [SerializeField] private Sprite fromTheBeyondSprite;
    [SerializeField] private Sprite oldGodsMurmursSprite;

    //Tomes
    //decayedDictionary
    [SerializeField] private Sprite fireballSprite;
    [SerializeField] private Sprite lightningSprite;
    //diviningGuide
    [SerializeField] private Sprite ghostGrappleSprite;
    [SerializeField] private Sprite curseSprite;
    //librariansLedger
    [SerializeField] private Sprite SHHHHHHSprite;
    [SerializeField] private Sprite overdueFeesSprite;
    //planisphere
    [SerializeField] private Sprite starfallSprite;
    [SerializeField] private Sprite meteoricMightSprite;

    private void Start()
    {
        healthText.text = "Health: " + health.ToString() + "/" + maxHealth.ToString();
        manaText.text = "Mana: " + mana.ToString() + "/" + maxMana.ToString();
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
        UpdateAllStatsUI();
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
        UpdateAllStatsUI();
    }

    public void ChangeAttack(int amount)
    {
        attack += amount;
        attackText.text = "Attack: " + attack.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void ChangeDefense(int amount)
    {
        defense += amount;
        defenseText.text = "Defense: " + defense.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void ChangeStrength(int amount)
    {
        strength += amount;
        strengthText.text = "Strength: " + strength.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void ChangeDexterity(int amount)
    {
        dexterity += amount;
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void ChangeIntelligence(int amount)
    {
        intelligence += amount;
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void ChangeCharisma(int amount)
    {
        charisma += amount;
        charismaText.text = "Charisma: " + charisma.ToString();
        // Update UI
        UpdateAllStatsUI();
    }

    public void SelectingWeapon(string weaponName)
    {
        var weaponData = WeaponHandling.GetWeaponDataByName(weaponName);
        if (weaponData == null)
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
        switch (weaponData.name)
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
            //Blades
            case "Cutlass":
                weaponIcon.sprite = cutlassSprite;
                skillIcon1.sprite = swabTheDeckSprite;
                skillIcon2.sprite = boardingPartySprite;
                break;
            case "Buster Sword":
                weaponIcon.sprite = busterSwordSprite;
                skillIcon1.sprite = HeaveSprite;
                skillIcon2.sprite = MomemtumSprite;
                break;
            case "Wooden Sword":
                weaponIcon.sprite = woodenSwordSprite;
                skillIcon1.sprite = thrustSprite;
                skillIcon2.sprite = SpinSprite;
                break;
            case "Sacrificial Dagger":
                weaponIcon.sprite = sacrificialDaggerSprite;
                skillIcon1.sprite = fromTheBeyondSprite;
                skillIcon2.sprite = oldGodsMurmursSprite;
                break;
            //Tomes
            case "Decayed Dictionary":
                weaponIcon.sprite = decayedDictionarySprite;
                skillIcon1.sprite = fireballSprite;
                skillIcon2.sprite = lightningSprite;
                break;
            case "Divining Guide":
                weaponIcon.sprite = diviningGuideSprite;
                skillIcon1.sprite = ghostGrappleSprite;
                skillIcon2.sprite = curseSprite;
                break;
            case "Librarian's Ledger":
                weaponIcon.sprite = librariansLedgerSprite;
                skillIcon1.sprite = SHHHHHHSprite;
                skillIcon2.sprite = overdueFeesSprite;
                break;
            case "Planisphere":
                weaponIcon.sprite = planisphereSprite;
                skillIcon1.sprite = starfallSprite;
                skillIcon2.sprite = meteoricMightSprite;
                break;
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

    public void SetMaxHealth()
    {
        health = maxHealth;
    }

    public void UpdateAllStatsUI()
    {
        healthText.text = "Health: " + health.ToString() + "/" + maxHealth.ToString();
        manaText.text = "Mana: " + mana.ToString() + "/" + maxMana.ToString();
        attackText.text = "Attack: " + attack.ToString();
        defenseText.text = "Defense: " + defense.ToString();
        strengthText.text = "Strength: " + strength.ToString();
        dexterityText.text = "Dexterity: " + dexterity.ToString();
        intelligenceText.text = "Intelligence: " + intelligence.ToString();
        charismaText.text = "Charisma: " + charisma.ToString();
        // Add other stats as needed
    }


}