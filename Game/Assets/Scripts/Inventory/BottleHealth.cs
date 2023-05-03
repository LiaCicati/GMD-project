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
                // Check if the player's health is less than the maximum health
                if (playerCustomController.currentHealth < playerCustomController.maxHealth) {
                    // Call the BottleCollected() method on the PlayerInventory component
                    playerInventory.BottleCollected();
                
                    // Increase player's health
                    playerCustomController.IncreaseHealth(25);
                    AudioManager.instance.Play("Heal");
                    
                    // Deactivate the bottle potion that was collected
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
