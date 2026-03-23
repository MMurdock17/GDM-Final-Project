using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    [Header("Pool Settings")]
    public GameObject prefab;
    public int initialSize = 10;

    private List<GameObject> pooledObjects = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Reusing object from pool: " + obj.name);
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefab);
        pooledObjects.Add(newObj);

        Debug.Log("Instantiating new object: " + newObj.name);

        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        Debug.Log("Returning object to pool: " + obj.name);
        obj.SetActive(false);
    }

}
