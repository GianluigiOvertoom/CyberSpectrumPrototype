using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColliderData : ScriptableObject
{
    public GameObject m_Parent;
    public LayerMask m_LayerMask;
    public Vector2 m_HitBoxOffset;
    public Vector2 m_HitBoxSize;
}

public class ColliderSpawner : MonoBehaviour
{
    public GameObject m_HitBox;
    public ColliderData m_ColliderData;

    public List<Collider2D> m_HitBoxPool;
    public Dictionary<ColliderData, Queue<GameObject>> m_HitBoxDictionary;

    private void Start()
    {
        /*
        m_HitBoxDictionary = new Dictionary<ColliderData, Queue<GameObject>>();

        Queue<GameObject> colliderPool = new Queue<GameObject>();

        for (int i = 0; i < 20; i++)
        {
            GameObject obj = GameObject.Instantiate(m_HitBox);
            obj.SetActive(false);
            colliderPool.Enqueue(obj);           
        }
        m_HitBoxDictionary.Add(m_ColliderData, colliderPool);
        */
    }

    private void SpawnCollider(ColliderData colliderData)
    {
        //GameObject hitboxToSpawn = m_ColliderList.Contains()
    }

    public void SpawnHitbox()
    {

    }

    private void Awake()
    {
        //SpawnCollider(this.gameObject);
    }
}
