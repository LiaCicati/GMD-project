using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // TextMeshProUGUI component to display the number of diamonds
    [SerializeField] private TextMeshProUGUI diamondText;

    // The diamond image GameObject
    [SerializeField] private Image diamondImage;

    // The sprite to change to after collecting 5 diamonds
    [SerializeField] private Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory) 
    {
        // Clamp the number of collected diamonds between 0 and the total number of diamonds needed
        int numCollected = Mathf.Clamp(playerInventory.NumberOfDiamonds, 0, playerInventory.diamondsNeededForPandoraBox);

        // Set the diamond text to show how many diamonds the player has collected out of the total diamonds needed
        diamondText.text = numCollected.ToString() + "/" + playerInventory.diamondsNeededForPandoraBox;

        // Check if the player has collected all the required diamonds
        if (numCollected == playerInventory.diamondsNeededForPandoraBox) 
        {
            // Change the diamond image sprite
            diamondImage.GetComponent<Image>().sprite = newSprite;
            diamondText.text = "0/1";
        } 
    }
}
