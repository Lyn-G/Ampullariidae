using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{   //=============Item Data============//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public ItemType itemType;


    //=============Item Slot============//

    [SerializeField] private GameObject quantityTextObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool isSelected;
    private InventoryManager inventoryManager;
    public Sprite emptySlotSprite;

    //=============Equipped Slot============//
    [SerializeField] private EquippedSlot rangeSlot, meleeSlot;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        //Check if the item slot is empty
        if (!isFull)
        {
            //Add the item to the inventory
            //Update Name,  Sprite and Description
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            itemImage.sprite = itemSprite;
            this.itemDescription = itemDescription;
            this.itemType = itemType;

            //Update the quantity
            this.quantity = 1;
            isFull = true; // Set the slot to full

            return 0;
        }
        else
        {
            return quantity;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {

        if (isSelected)
        {
            EquipGear();
        }
        else
        {
            inventoryManager.DeselectAll();
            Debug.Log("Left click on " + itemName);
            selectedShader.SetActive(true);
            isSelected = true;

            // Fetch and display weapon stats
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<PlayerStats>().SelectingWeapon(itemName);
        }
    }

    private void OnRightClick()
    {
        Debug.Log("Right click on " + itemName);
        if (quantity > 0)
        {
            //create a new item
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.SetItemName(itemName);
            newItem.SetQuantity(1);
            newItem.SetSprite(itemSprite);
            newItem.SetItemDescription(itemDescription);
            newItem.itemType = itemType;

            //Create and modify the SR
            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = itemSprite;
            //sr.sortingOrder = 5;
            //sr.sortingLayerName = "Items";

            //Add a collider
            itemToDrop.AddComponent<BoxCollider>();

            //Set the position of the item to the player's position's right side
            itemToDrop.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(2f, 0, 0);

            //set size of the item
            itemToDrop.transform.localScale = new Vector3(.3f, .3f, .3f);

            //subtract the quantity
            this.quantity = 0;
            EmptySlot();
        }
    }

    public void EmptySlot()
    {
        itemName = "";
        quantity = 0;
        itemDescription = "";
        isFull = false;
        itemImage.sprite = emptySlotSprite;
    }

    public void EquipGear()
    {
        if (itemType == ItemType.Melee)
        {
            meleeSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.Range)
        {
            rangeSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        EmptySlot();
    }
}
