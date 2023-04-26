using UnityEngine;

public class PandoraBox: MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // Check if the player has collected all the diamonds
        PlayerInventory playerInventory = other.GetComponent <PlayerInventory> ();
        if (playerInventory != null && playerInventory.NumberOfDiamonds >= playerInventory.diamondsNeededForPandoraBox) {
            // Player has won the game!
            Debug.Log("Congratulations, you found the Pandora Box!");

            // Destroy the Pandora Box
            Destroy(gameObject);
            
            // Set the game state to indicate that the game has been won
            GameState.isGameWon = true;
            RestartGame restartGame =  FindObjectOfType<RestartGame>();
            restartGame.EndGame();
        }
    }
}