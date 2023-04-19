using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // Event to be invoked when a diamond is collected
    public UnityEvent<PlayerInventory> onDiamondCollected;

    // Property to get the number of collected diamonds
    public int NumberOfDiamonds { get; private set; }

    // Method called when a diamond is collected
    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        onDiamondCollected.Invoke(this);
    }
}