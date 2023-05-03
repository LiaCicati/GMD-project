using UnityEngine;
using System.Collections.Generic;


public class ObjectPool : MonoBehaviour
{
    public GameObject pooledObject;
    public int poolSize = 10;

    private List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i] != null && !pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        GameObject obj = Instantiate(pooledObject, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

}

