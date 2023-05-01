using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // Event to be invoked when a diamond is collected
    public UnityEvent<PlayerInventory> onDiamondCollected;

    // Property to get the number of collected diamonds
    public int NumberOfDiamonds { get; private set; }

    // Reference to the Pandora Box prefab
    public GameObject pandoraBoxPrefab;

    // The number of diamonds required to spawn a Pandora Box
    public int diamondsNeededForPandoraBox = 5;

    // Flag to track whether a Pandora Box has already been spawned
    private bool hasSpawnedPandoraBox = false;



    // Method called when a diamond is collected
    public void DiamondCollected() 
    {
        NumberOfDiamonds++;

        // Invoke the onDiamondCollected event and pass this PlayerInventory instance as a parameter
        onDiamondCollected.Invoke(this);

        // Try to spawn a Pandora Box if enough diamonds have been collected
        TrySpawnPandoraBox();
    }

    // Method to attempt spawning a Pandora Box
    private void TrySpawnPandoraBox() 
    {
        // Only spawn a Pandora Box if enough diamonds have been collected and one hasn't already been spawned
        if (NumberOfDiamonds >= diamondsNeededForPandoraBox && !hasSpawnedPandoraBox) 
        {
            // Spawn the Pandora Box at a random position within a certain range
            SpawnPandoraBox();

            // Set the hasSpawnedPandoraBox flag to true to prevent further spawning
            hasSpawnedPandoraBox = true;
        }
    }

    // Method to spawn a Pandora Box at a random position
    private void SpawnPandoraBox() 
    {
        // Determine a random spawn position within a certain range
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 30f), 0.5f, Random.Range(-10f, 30f));

        // Instantiate the Pandora Box prefab at the determined position with no rotation
        Instantiate(pandoraBoxPrefab, spawnPosition, Quaternion.identity);
    }
}
