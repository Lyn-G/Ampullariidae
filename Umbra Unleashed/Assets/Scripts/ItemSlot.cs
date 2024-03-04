using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{   //=============Item Data============//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    //=============Item Slot============//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private GameObject quantityTextObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        quantityText.text = quantity.ToString();
        quantityTextObject.SetActive(true); // Set the quantity text object to active
        isFull = true;
    }
}
