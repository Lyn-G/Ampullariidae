using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject panel; // Assign your panel GameObject here in the inspector
    private bool isOpen = false;

    public ItemSlot[] itemSlots; // Assign your item slots here in the inspector

    public ItemSO[] itemSOs; // Assign your Scriptable Items here in the inspector
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

    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
                return;
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Add the item to the inventory
        Debug.Log("Added " + quantity + " " + itemName + " (" + itemSprite+ ") to the inventory");
        Debug.Log("Item Description: " + itemDescription);

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull && itemSlots[i].itemName == itemName||itemSlots[i].quantity == 0)
            {
                int leftOverItems = itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if(leftOverItems>0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);//Recursive call to add the left over items
                    
                }
                return leftOverItems;
            }
        }
        return quantity;
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
