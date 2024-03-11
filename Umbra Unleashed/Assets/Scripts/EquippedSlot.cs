using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquippedSlot : MonoBehaviour
{
    //Slot Appearance//
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotName;
    [SerializeField] private GameObject slotNameObject; // This is the object that holds the quantity text and is set to active when the item is added

    //Slot Data//
    [SerializeField] private ItemType itemType = new ItemType();
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    //Other Variables//
    private bool slotInUse;

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        this.itemSprite = itemSprite;
        slotImage.sprite = itemSprite;
        slotName.text = itemName;
        slotNameObject.SetActive(false);
        
        this.itemName = itemName;
        this.itemDescription = itemDescription;


        slotInUse = true;
    }
}
