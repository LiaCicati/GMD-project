using UnityEngine;

public class PandoraBox: MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // Check if the player has collected all the diamonds
        PlayerInventory playerInventory = other.GetComponent <PlayerInventory> ();
        if (playerInventory != null && playerInventory.NumberOfDiamonds >= playerInventory.diamondsNeededForPandoraBox) {
            
            Debug.Log("Congratulations, you found the Pandora Box!");
            // Play audio for collecting box
            AudioManager.instance.Play("GameWin");

            // Destroy the Pandora Box
            Destroy(gameObject);
            
            // Set the game state to indicate that the game has been won
            GameState.isGameWon = true;
        }
    }
}