using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject panel; // Assign your panel GameObject here in the inspector
    private bool isOpen = false;

    public ItemSlot[] itemSlots; // Assign your item slots here in the inspector

    void Start()
    {
        // Initialize isOpen based on the panel's initial active state
        isOpen = panel.activeSelf;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            panel.SetActive(isOpen);
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Add the item to the inventory
        Debug.Log("Added " + quantity + " " + itemName + " (" + itemSprite+ ") to the inventory");
        Debug.Log("Item Description: " + itemDescription);

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }
     public void DeselectAll()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].isSelected = false;
        }
    }
}
