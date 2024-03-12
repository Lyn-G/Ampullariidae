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

    //Other Variables//
    private bool slotInUse;
    [SerializeField] public GameObject selectedShader;
    [SerializeField] public bool isSelected;
    [SerializeField] private Sprite emptySlotSprite;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {   
        //On Left Click
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        //On Right Click
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

    }
    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        //If something is already equipped, unequip it
        if(slotInUse)
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
    }

    public void UnequipGear()
    {
        inventoryManager.DeselectAll();
        inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType);
        //Unequip the item
        this.itemSprite = emptySlotSprite;
        slotImage.sprite = emptySlotSprite;
        slotNameObject.SetActive(true);
    }
    public void OnLeftClick()
    {
        if(isSelected&&slotInUse)
        {
            UnequipGear();
        }
        else
        {
            inventoryManager.DeselectAll();
            selectedShader.SetActive(true);
            isSelected = true;
        }
    }

    public void OnRightClick()
    {
        UnequipGear();
    }
    
}
