using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour, IPoolObject
{
    #region Interface
    void IPoolObject.ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    void IPoolObject.ReturnToPoolWithDelay(float delay)
    {
        Invoke("ReturnToPool", delay);
    }
    #endregion
}

public interface IPoolObject
{
    void ReturnToPool();

    void ReturnToPoolWithDelay(float delay);
}

public interface IDestroyableMonobehaviour
{
    void Destroy();
}

public class DestroyableMonobehaviour: IDestroyableMonobehaviour
{
    MonoBehaviour mono;
    public DestroyableMonobehaviour(MonoBehaviour mono)
    {
        this.mono = mono;
    }

    void IDestroyableMonobehaviour.Destroy()
    {
        Object.Destroy(this.mono);
    }
}

