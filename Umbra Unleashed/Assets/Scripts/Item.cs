using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    //Getters for the item's name, quantity, sprite, and description
    public string GetItemName() => itemName;
    public int GetQuantity() => quantity;
    public Sprite GetSprite() => sprite;
    public string GetItemDescription() => itemDescription;

    //Setters for the item's name, quantity, sprite, and description
    public void SetItemName(string itemName) => this.itemName = itemName;
    public void SetQuantity(int quantity) => this.quantity = quantity;
    public void SetSprite(Sprite sprite) => this.sprite = sprite;
    public void SetItemDescription(string itemDescription) => this.itemDescription = itemDescription;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                quantity = leftOverItems;
            }
            Destroy(gameObject);
        }
    }
}
