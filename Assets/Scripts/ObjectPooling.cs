using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling current;
    public GameObject objectToPool;
    public int pooledAmount = 3;
    public bool willGrow = true;
    public List<GameObject> pooledObjects;

    void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < pooledAmount; j++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    public GameObject GetpooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }

}
