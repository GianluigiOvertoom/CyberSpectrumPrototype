using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePool : MonoBehaviour
{
    public ObjectPool m_ObjectPool { get; set; }
    public ObjectPoolList m_Pools;

    private void Start()
    {
        m_ObjectPool = new ObjectPool();
        m_ObjectPool.SpawnPool(m_Pools.m_PoolArray);
    }
}
