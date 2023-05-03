using UnityEngine;

// Class to handle spawn of diamonds
public class DiamondSpawner : MonoBehaviour
{
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] private int numberOfDiamonds;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnHeight;

    private void Start()
    {
        for (int i = 0; i < numberOfDiamonds; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));
            Instantiate(diamondPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
