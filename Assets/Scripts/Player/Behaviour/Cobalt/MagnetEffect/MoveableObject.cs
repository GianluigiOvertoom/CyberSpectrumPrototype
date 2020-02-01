using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    horizontal,
    vertical
}

public class MoveableObject : MonoBehaviour
{
    public MovementDirection m_MovementDirection;
    public bool m_HasGravity;
    public PolarBehaviour m_PolarBehaviour { get; set; }

    private Rigidbody2D m_Rigidbody2D;
    private float m_MoveTimeLimit = 0.1f;
    private float m_MoveTimer;
    private float m_Force;
    private Vector2 m_Direction;

    private CreatePool m_SpecialEffect;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_MoveTimer = 0f;
        m_Force = 5f;
        if (m_HasGravity)
            return;
        m_Rigidbody2D.gravityScale = 0f;       
    }

    private void Start()
    {
        m_SpecialEffect = GameObject.FindObjectOfType<CreatePool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            m_MoveTimer = 0f;
            m_SpecialEffect.m_ObjectPool.SpawnFromPool("DamageParticle", transform.position, new Quaternion(Random.value, Random.value, Random.value, Random.value));
        }
    }

    private void FixedUpdate()
    {
        MoveObject();
        if (m_PolarBehaviour == null)
        {
            m_Rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            return;
        }
    }

    public void AddPolar(PolarBehaviour polarBehaviour)
    {
        m_PolarBehaviour = polarBehaviour;
    }

    public void RemovePolar()
    {
        m_PolarBehaviour = null;
    }

    private void MoveObject()
    {
        if (m_MoveTimer >= m_MoveTimeLimit)
        {
            m_Rigidbody2D.velocity = Vector2.zero;           
        }
        else
        {
            m_MoveTimer += Time.deltaTime;           
            switch (m_MovementDirection)
            {               
                case MovementDirection.horizontal:
                    if (m_PolarBehaviour == null)
                        return;
                    switch (m_PolarBehaviour.m_PolarType)
                    {
                        case PolarType.neutron:
                            m_Direction = Vector2.left;
                            break;
                        case PolarType.proton:
                            m_Direction = Vector2.right;
                            break;
                        default:
                            m_Direction = Vector2.zero;
                            break;
                    }
                    break;
                case MovementDirection.vertical:
                    if (m_PolarBehaviour == null)
                        return;
                    switch (m_PolarBehaviour.m_PolarType)
                    {
                        case PolarType.neutron:
                            m_Direction = Vector2.down;
                            break;
                        case PolarType.proton:
                            m_Direction = Vector2.up;
                            break;
                        default:
                            m_Direction = Vector2.zero;
                            break;
                    }
                    break;
            }
            m_Rigidbody2D.velocity = m_Direction * m_Force;
        }
    }
}
