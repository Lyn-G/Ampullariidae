using UnityEngine;

public class BackpackToggle : MonoBehaviour
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
}
