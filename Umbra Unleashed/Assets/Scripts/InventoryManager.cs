using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject BackPackpanel; // Assign your panel GameObject here in the inspector
    public GameObject Equipmentpanel; // Assign your panel GameObject here in the inspector
    private bool isOpen = false;

    public ItemSlot[] itemSlots; // Assign your item slots here in the inspector
    public EquipmentSlot[] equipmentSlots; // Assign your equipment slots here in the inspector
    public EquippedSlot[] equippedSlots; // Assign your equipped slots here in the inspector
    public ItemSO[] itemSOs; // Assign your Scriptable Items here in the inspector
    void Start()
    {
        // Initialize isOpen based on the panel's initial active state
        isOpen = BackPackpanel.activeSelf;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            Equipmentpanel.SetActive(false);
            BackPackpanel.SetActive(isOpen);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            BackPackpanel.SetActive(false);
            Equipmentpanel.SetActive(isOpen);
        }
    }

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool isUsable = itemSOs[i].UseItem();
                return isUsable;
            }
        }
        return false;
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        // Add the item to the inventory
        Debug.Log("Added " + quantity + " " + itemName + " (" + itemSprite+ ") to the inventory");
        Debug.Log("Item Description: " + itemDescription);

        if(itemType == ItemType.Consumable || itemType == ItemType.Collectible)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (!itemSlots[i].isFull && itemSlots[i].itemName == itemName || itemSlots[i].quantity == 0)
                {
                    int leftOverItems = itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);//Recursive call to add the left over items

                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }
        else //If the item is fist/blade/tome/staff
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (!equipmentSlots[i].isFull && equipmentSlots[i].itemName == itemName || equipmentSlots[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);//Recursive call to add the left over items

                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }


    }
     public void DeselectAll()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].isSelected = false;
        }
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].selectedShader.SetActive(false);
            equipmentSlots[i].isSelected = false;
        }
        for (int i = 0; i < equippedSlots.Length; i++)
        {
            equippedSlots[i].selectedShader.SetActive(false);
            equippedSlots[i].isSelected = false;
        }
    }
}

public enum ItemType
{
    Consumable,
    Melee,
    Range,
    Collectible,
};