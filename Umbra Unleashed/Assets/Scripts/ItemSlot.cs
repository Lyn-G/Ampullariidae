using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{   //=============Item Data============//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    [SerializeField]private int maxNumberOfItems;

    //=============Item Slot============//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private GameObject quantityTextObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image itemImage;

    //=============Item Description Slot============//
    public Image itemDescriptionImage;
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    public bool isSelected;
    private InventoryManager inventoryManager;
    public Sprite emptySlotSprite;


    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
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

            //Update the quantity
            this.quantity += quantity;
            if (this.quantity >= maxNumberOfItems)
            {
                quantityText.text = maxNumberOfItems.ToString();
                quantityTextObject.SetActive(true); // Set the quantity text object to active
                isFull = true;
            

            //Return the left over items
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
            }

            //Update the quantity text
            quantityText.text = this.quantity.ToString();
            quantityTextObject.SetActive(true); // Set the quantity text object to active

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
        inventoryManager.DeselectAll();
        Debug.Log("Left click on " + itemName);
        selectedShader.SetActive(true);
        isSelected = true;
        itemDescriptionImage.sprite = itemSprite;
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        if (itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.sprite = emptySlotSprite;
        }

    }

    private void OnRightClick()
    {
        Debug.Log("Right click on " + itemName);
    }


}
