using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject panel; // Assign your panel GameObject here in the inspector
    private bool isOpen = false;

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

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        // Add the item to the inventory
        Debug.Log("Added " + quantity + " " + itemName + " (" + itemSprite+ ") to the inventory");
    }
}
