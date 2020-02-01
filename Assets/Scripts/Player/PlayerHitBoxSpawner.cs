using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxSpawner : MonoBehaviour
{
    private PlayerPhysicsBehaviour m_PlayerPhysicsBehaviour;
    private PlayerHitBoxBehaviour m_HitBox;

    private void Awake()
    {
        m_HitBox = GameObject.FindObjectOfType<PlayerHitBoxBehaviour>();
        m_PlayerPhysicsBehaviour = GameObject.FindObjectOfType<PlayerPhysicsBehaviour>();
    }

    private void Start()
    {
        DisableCollider();
    }

    public void DisableCollider()
    {
        m_HitBox.gameObject.SetActive(false);
    }

    public void SetNewHitboxCoordiates(Vector2 offset, Vector2 size)
    {
        m_HitBox.m_HitBoxOffset = new Vector2(offset.x, offset.y);
        m_HitBox.m_HitBoxSize = size;
    }

    public void SpawnHitBox()
    {
        m_HitBox.gameObject.SetActive(true);
    }
}
