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
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private GameObject quantityTextObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool isSelected;
    private InventoryManager inventoryManager;
    public Sprite emptySlotSprite;



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
            bool isUsable = inventoryManager.UseItem(itemName);
            Debug.Log("isUsable: " + isUsable);
            if (isUsable)
            {

                this.quantity--;
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
            inventoryManager.DeselectAll();
            Debug.Log("Left click on " + itemName);
            selectedShader.SetActive(true);
            isSelected = true;
        }
    }

    private void OnRightClick()
    {
        Debug.Log("Right click on " + itemName);
        //create a new item
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.SetItemName(itemName);
        newItem.SetQuantity(1);
        newItem.SetSprite(itemSprite);
        newItem.SetItemDescription(itemDescription);

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
        this.quantity--;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
        {
            EmptySlot();
        }
    }

    public void EmptySlot()
    {
        
        quantity = 0;
        itemSprite = emptySlotSprite;
        
        isFull = false;
        quantityText.text = "";

        quantityTextObject.SetActive(false);
        //itemImage.sprite = emptySlotSprite;
    }
}
