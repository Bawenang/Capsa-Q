using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPool(IPooledObject pooledObject);
public delegate void OnObjectExitPool();

public interface IPooledObject
{
    void OnRetrievedFromPool();
    void OnReturnedToPool();
}

public abstract class PooledObject: MonoBehaviour, IPooledObject
{
    public abstract void OnRetrievedFromPool();
    public abstract void OnReturnedToPool();
}