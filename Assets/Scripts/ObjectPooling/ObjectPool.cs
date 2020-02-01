using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    void OnObjectSpawn();
}

public class ObjectPool
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public void SpawnPool(Pool[] pools)
    {
        if (pools.Length == 0)
        {
            Debug.Log("No Pools Exist");
        }

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = GameObject.Instantiate(pool.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

            poolDictionary.Add(pool.name, objectpool);
        }
    }

    public GameObject SpawnFromPool(string poolName, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning("Pool with " + poolName + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolName].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledobj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledobj != null)
        {
            pooledobj.OnObjectSpawn();
        }

        poolDictionary[poolName].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
