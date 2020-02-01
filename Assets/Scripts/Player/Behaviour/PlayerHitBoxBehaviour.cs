using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxBehaviour : MonoBehaviour
{
    public Vector2 m_HitBoxOffset { get; set; }
    public Vector2 m_HitBoxSize { get; set; }
    public LayerMask m_LayerMask;

    private ParticlePool m_SpecialEffect;
    private PlayerData m_PlayerData;
    private PlayerController m_PlayerController;
    private CreatePool m_PlayerPool;
    private Collider2D[] m_CollidedObjects;
    private List<GameObject> m_CollidedObjectList;
    private PolarBehaviour m_PolarBehaviour;

    private void Awake()
    {
        m_PlayerData = GameObject.FindObjectOfType<PlayerData>();
        m_PlayerController = GameObject.FindObjectOfType<PlayerController>();

        m_CollidedObjectList = new List<GameObject>();
    }

    private void Start()
    {
        m_PlayerPool = m_PlayerController.m_PlayerPool;

        m_SpecialEffect = GameObject.FindObjectOfType<ParticlePool>();
    }

    private void Update()
    {
        m_CollidedObjects = Physics2D.OverlapBoxAll(m_HitBoxOffset, m_HitBoxSize, 0f, m_LayerMask);

        for (int i = 0; i < m_CollidedObjects.Length; i++)
        {            
            if (m_CollidedObjectList.Contains(m_CollidedObjects[i].gameObject))
                return;
            m_CollidedObjectList.Add(m_CollidedObjects[i].gameObject);
            CollisionEnter(m_CollidedObjects[i].gameObject);
        }
    }

    private void CollisionEnter(GameObject collision)
    {
        m_SpecialEffect.m_ObjectPool.SpawnFromPool("DamageParticle", collision.transform.position, new Quaternion(Random.value, Random.value, Random.value, Random.value));
        switch (m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                switch (m_PlayerData.m_ActiveColor)
                {
                    case ActiveColor.normal:
                        if (collision.transform.childCount > 1)
                        {
                            if (!collision.GetComponent<MoveableObject>())
                                return;
                            collision.GetComponent<MoveableObject>().m_PolarBehaviour.DisableObject();
                            GameObject NeutronMark = m_PlayerPool.m_ObjectPool.SpawnFromPool("CobaltNeutronPolar", collision.transform.position, Quaternion.identity);
                            NeutronMark.transform.parent = collision.transform;                            
                        }
                        else
                        {
                            GameObject NeutronMark = m_PlayerPool.m_ObjectPool.SpawnFromPool("CobaltNeutronPolar", collision.transform.position, Quaternion.identity);
                            NeutronMark.transform.parent = collision.transform;
                        }
                        break;
                    case ActiveColor.alt:
                        if (collision.transform.childCount > 1)
                        {
                            if (!collision.GetComponent<MoveableObject>())
                                return;
                            collision.GetComponent<MoveableObject>().m_PolarBehaviour.DisableObject();
                            GameObject ProtonMark = m_PlayerPool.m_ObjectPool.SpawnFromPool("CobaltProtonPolar", collision.transform.position, Quaternion.identity);
                            ProtonMark.transform.parent = collision.transform;                           
                        }
                        else
                        {
                            GameObject ProtonMark = m_PlayerPool.m_ObjectPool.SpawnFromPool("CobaltProtonPolar", collision.transform.position, Quaternion.identity);
                            ProtonMark.transform.parent = collision.transform;
                        }
                        break;
                }
                break;
            case ActiveCharacter.crimson:
                switch (m_PlayerData.m_ActiveColor)
                {
                    case ActiveColor.normal:
                        break;
                    case ActiveColor.alt:
                        break;
                }
                break;
        }
    }

    private void OnDisable()
    {
        m_CollidedObjectList.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(m_HitBoxOffset, m_HitBoxSize);
    }
}
