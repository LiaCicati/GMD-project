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

    // Number of diamonds needed to spawn the Pandora Box
    public int diamondsNeededForPandoraBox = 5;

    private bool hasSpawnedPandoraBox = false;


    // Method called when a diamond is collected
 public void DiamondCollected() {
   NumberOfDiamonds++;
   onDiamondCollected.Invoke(this);

   // Check if the player has collected enough diamonds to spawn the Pandora Box
   if (NumberOfDiamonds >= diamondsNeededForPandoraBox && !hasSpawnedPandoraBox) {
     // Spawn the Pandora Box randomly in the scene
     Vector3 spawnPosition = new Vector3(Random.Range(-10f, 30f), 0.5f, Random.Range(-10f, 30f));
     Instantiate(pandoraBoxPrefab, spawnPosition, Quaternion.identity);

     // Set the flag to true to indicate that the Pandora Box has been spawned
     hasSpawnedPandoraBox = true;
   }
 }
 }