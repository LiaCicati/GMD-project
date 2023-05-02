using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            // Call the DiamondCollected() method on the PlayerInventory component
            playerInventory.DiamondCollected();
            if (playerInventory.NumberOfDiamonds == playerInventory.diamondsNeededForPandoraBox)
            {
                // Deactivate the game object of the remaining diamonds
                Diamond[] diamonds = FindObjectsOfType<Diamond>();
                foreach (Diamond diamond in diamonds)
                {
                    if (diamond.gameObject.activeSelf)
                    {
                        diamond.gameObject.SetActive(false);
                    }
                }
            }
            // Deactivate the diamond that was collected
            gameObject.SetActive(false);
        }
    }
}