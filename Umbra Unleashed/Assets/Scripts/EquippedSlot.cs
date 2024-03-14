using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //Slot Appearance//
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotName;
    [SerializeField] private GameObject slotNameObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image playerDisplayImage;
    //Slot Data//
    [SerializeField] private ItemType itemType = new ItemType();
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private int statChangeAmount;

    //Other Variables//
    private bool slotInUse;
    [SerializeField] public GameObject selectedShader;
    [SerializeField] public bool isSelected;
    [SerializeField] private Sprite emptySlotSprite;

    private InventoryManager inventoryManager;
    private WeaponHandling weaponHandling;

    // Variables to update Player's current weapon
    public GameObject Player;
    public GameObject PlayerWeapon;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        weaponHandling = GameObject.Find("JsonHandler").GetComponent<WeaponHandling>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //On Left Click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        //On Right Click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

    }
    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        //If something is already equipped, unequip it
        if (slotInUse)
        {
            UnequipGear();
        }

        //Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = itemSprite;
        slotNameObject.SetActive(false);

        //Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        //Update the Display Image
        playerDisplayImage.sprite = itemSprite;
        slotInUse = true;
        
        //Update Player Attack stat
        PlayerStats stats = GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>();
        var weaponData = WeaponHandling.GetWeaponDataByName(itemName);
        string weaponType = weaponData.type;
        int strength = stats.GetStatValue("Strength");
        int dexterity = stats.GetStatValue("Dexterity");
        int intelligence = stats.GetStatValue("Intelligence");
        int charisma = stats.GetStatValue("Charisma");
        Debug.Log("Equip: Updating Player Attack Stat...");
        Debug.Log("Strength: " + strength);
        Debug.Log("Dexterity: " + dexterity);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Charisma: " + charisma);
        if (weaponType == "Blade")
        {
            Debug.Log("Blade");
            statChangeAmount = (int)(strength * 0.4 + dexterity * 0.6);
        }
        else if (weaponType == "Fists")
        {
            Debug.Log("Fists");
            statChangeAmount = (int)(strength * 0.6 + dexterity * 0.4);
        }
        else if (weaponType == "Tome")
        {
            Debug.Log("Tome");
            statChangeAmount = (int)(charisma * 0.6 + intelligence * 0.4);
        }
        else if (weaponType == "Staff")
        {
            Debug.Log("Staff");
            statChangeAmount = (int)(charisma * 0.4 + intelligence * 0.6);
        }
        else
        {
            Debug.Log("No Weapon Type Found");
        }
        Debug.Log("Stat Change Amount: " + statChangeAmount);
        GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeAttack(statChangeAmount);

        //Update Player's current weapon if its a Staff or Tome by changing its sprite
        if (weaponType == "Staff" || weaponType == "Tome")
        {
            PlayerWeapon.GetComponent<SpriteRenderer>().sprite = itemSprite;
            PlayerWeapon.GetComponent<WeaponInfo>().LoadWeaponData();
            Player.GetComponent<PlayerController>().LoadWeaponData();
        }

    }

    public void UnequipGear()
    {
        if(!slotInUse)
        {
            return;
        }
        inventoryManager.DeselectAll();
        inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType);
        //Unequip the item
        itemName = "";
        itemDescription = "";
        this.itemSprite = emptySlotSprite;
        slotImage.sprite = emptySlotSprite;
        slotNameObject.SetActive(true);
        slotInUse = false;

        //Updating Player Attack

        Debug.Log("UnEquip: Updating Player Attack Stat...");
        GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().ChangeAttack(-statChangeAmount);

        //Updating Weapon Stat UI
        GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().DeselectingWeapon();
        
    }
    public void OnLeftClick()
    {
        if (isSelected && slotInUse)
        {
            UnequipGear();
        }
        else
        {
            inventoryManager.DeselectAll();
            selectedShader.SetActive(true);
            isSelected = true;
            // Fetch and display weapon stats
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().SelectingWeapon(itemName);
        }
    }

    public void OnRightClick()
    {
        UnequipGear();
    }

}
