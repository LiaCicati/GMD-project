using UnityEngine;
using System.Collections.Generic;


// Object pool to manage bullets (pre-instantiate a certain number of bullets and then reuse them as needed)
public class ObjectPool : MonoBehaviour
{
    public GameObject pooledObject;
    public int poolSize = 10;

    private List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>(poolSize);
        
       // Pre-instantiate the objects in the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Get an inactive object from the pool
    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i] != null && !pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        // If no inactive objects are found in the pool, create a new one
        GameObject obj = Instantiate(pooledObject, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

}

