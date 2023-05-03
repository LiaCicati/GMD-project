using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bottlePrefab;
    [SerializeField] private int numberOfBottles;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnHeight;

    private void Start()
    {
        for (int i = 0; i < numberOfBottles; i++)
        {
            // Generate a random spawn position within the specified range and height
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, Random.Range(-spawnRange, spawnRange));
            
            // Instantiate the bottlePrefab 
            Instantiate(bottlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}