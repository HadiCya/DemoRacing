using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        //create pool and set all objects to inactive
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //search through pool for an object to use. allows the pool to be used across scripts
    public GameObject GetPooledObject()
    {
        //loop to search through pool
        for(int i = 0; i < amountToPool; i++)
        {
            //get first available object
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    public void ResetPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }
}
