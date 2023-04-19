using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // TextMeshProUGUI component to display the number of diamonds
    private TextMeshProUGUI diamondText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        // Set the diamond text to the number of diamonds collected as a string
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();
    }
}
