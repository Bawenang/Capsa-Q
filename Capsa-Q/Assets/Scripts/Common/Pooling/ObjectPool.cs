using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public PooledObject sourcePrefab;
    private Stack<PooledObject> objectStack = new Stack<PooledObject>();

    public PooledObject Instantiate(Vector3 position, Quaternion rotation)
    {
        PooledObject pooledObject;
        if(objectStack.Count > 0) { 
            pooledObject = objectStack.Pop();

        }
        else {
            GameObject pooledGO = Instantiate(sourcePrefab.gameObject, position, rotation);
            pooledObject = pooledGO.GetComponent<PooledObject>();
        }

        pooledObject.gameObject.SetActive(true);
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        return pooledObject;
    }

    public void Remove(PooledObject pooledObject)
    {
        pooledObject.transform.position = this.transform.position;
        pooledObject.transform.rotation = this.transform.rotation;
        pooledObject.transform.parent = this.transform;
        pooledObject.gameObject.SetActive(false);
        objectStack.Push(pooledObject);
    }
}
