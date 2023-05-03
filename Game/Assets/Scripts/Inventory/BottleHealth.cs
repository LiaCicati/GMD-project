using UnityEngine;

public class BottleHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            PlayerCustomController playerCustomController = other.GetComponent<PlayerCustomController>();
            if (playerCustomController != null) {
                // Call the BottleCollected() method on the PlayerInventory component
                playerInventory.BottleCollected();
                
                // Increase player's health
                playerCustomController.IncreaseHealth(25);
            }
            
            // Deactivate the bottle that was collected
            gameObject.SetActive(false);
        }
    }
}
