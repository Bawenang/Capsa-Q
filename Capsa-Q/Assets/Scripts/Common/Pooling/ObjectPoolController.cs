using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public static ObjectPoolController Instance { 
        get {
            return instance;
        }
    }

    public static void DestroyInstance() {
        if (instance == null) return;
        DestroyImmediate(instance.gameObject);
        instance = null;
    }
    private static ObjectPoolController instance = null;
    [SerializeField] private PooledObject[] sourcePrefabs;  
    private Dictionary<Type, ObjectPool> objectPools = new Dictionary<Type, ObjectPool>();
    void Awake()
    {
        if (instance == null) {
            instance = this;
            CreatePools();
            DontDestroyOnLoad(this.gameObject);
        } else if (instance != this) {
            DestroyImmediate(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (instance == this) {
            instance = null;
        }
    }

    public PooledObject Instantiate<T>(Vector3 position, Quaternion rotation)
    {
        if(!objectPools.ContainsKey(typeof(T))) {
            return null;
        }

        return objectPools[typeof(T)].Instantiate(position, rotation);
    }

    public void Remove<T>(T pooledObject)
    {
        var pooledObjectToRemove = pooledObject as PooledObject;
        if(pooledObjectToRemove != null && !objectPools.ContainsKey(typeof(T))) {
            return;
        }

        objectPools[typeof(T)].Remove(pooledObjectToRemove);
    }

    private void CreatePools()
    {
        foreach (var prefab in sourcePrefabs)
        {
            CreatePool(prefab);
        }
    }
    private void CreatePool(PooledObject prefab)
    {
        GameObject poolGO = new GameObject(prefab.name);
        poolGO.transform.position = this.transform.position;
        poolGO.transform.rotation = this.transform.rotation;
        poolGO.transform.parent = this.transform;
        ObjectPool pool = poolGO.AddComponent<ObjectPool>();
        pool.sourcePrefab = prefab;
        objectPools.Add(prefab.GetType(), pool);
    }
}
