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

    public void UpdateDiamondText(PlayerInventory playerInventory) {
      // Clamp the number of collected diamonds between 0 and the total number of diamonds needed
      int numCollected = Mathf.Clamp(playerInventory.NumberOfDiamonds, 0, playerInventory.diamondsNeededForPandoraBox);

      // Set the diamond text to show how many diamonds the player has collected out of the total diamonds needed
      diamondText.text = numCollected.ToString() + "/" + playerInventory.diamondsNeededForPandoraBox.ToString();

      // Check if the player has collected all the required diamonds
      if (numCollected == playerInventory.diamondsNeededForPandoraBox) {
        // Set the font
        diamondText.fontSize = 30;

        // Change the text to prompt the player to find the Pandora Box
        diamondText.text = "Find the Pandora Box!";

      }
}
}