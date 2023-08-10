using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPool(Poolable pooledObject);
public delegate void OnObjectExitPool();

public interface Poolable
{
    void OnRetrievedFromPool();
    void OnReturnedToPool();
}

public abstract class PooledObject: MonoBehaviour, Poolable
{
    public abstract void OnRetrievedFromPool();
    public abstract void OnReturnedToPool();
}