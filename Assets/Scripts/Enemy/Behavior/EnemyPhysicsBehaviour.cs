using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovementState
{
    normalMovement,
    dashMovement,
    directionalMovement,
    fastDirectionalMovement,
    noMovement
}

public enum EnemyAerialState
{
    fullGravity,
    reducedGravity,
    zeroGravity
}

public class EnemyPhysicsBehaviour : MonoBehaviour
{
    public float m_Direction { get; set; }
    public Rigidbody2D m_Rigidbody2D { get; set; }

    //private EnemyBehaviour m_EnemyBehaviour;
    private float m_OriginalGravity;
    private float m_reducedGravity;

    private Vector2 m_CurrentPosition;
    private Vector2 m_NewPosition;

    private void Awake()
    {
        m_Direction = 1f;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        //m_EnemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    private void Start()
    {
        //m_OriginalGravity = m_PlayerBehaviour.m_PlayerData.m_OriginalGravity;
        //m_reducedGravity = m_PlayerBehaviour.m_PlayerData.m_ReducedGravity;
    }

    public void HandlePlayerDirection(SpriteRenderer spriteRenderer, bool canTurn)
    {
        m_NewPosition = m_Rigidbody2D.transform.position;
        if (canTurn)
        {
            if (m_CurrentPosition.x > m_NewPosition.x)
            {
                m_Direction = 1f;
                spriteRenderer.flipX = false;
                m_CurrentPosition = m_NewPosition;
            }
            else if (m_CurrentPosition.x < m_NewPosition.x)
            {
                m_Direction = -1f;
                spriteRenderer.flipX = true;
                m_CurrentPosition = m_NewPosition;
            }
        }
    }
    /*
    public void HandleSpeedLimit(float speedLimit, bool removeLimiter)
    {
        if (m_Rigidbody2D.velocity.y >= speedLimit && !removeLimiter)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, speedLimit);
        }
        if (m_Rigidbody2D.velocity.y <= -speedLimit && !removeLimiter)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -speedLimit);
        }
    }

    public EnemyMovementState SetMovementState(EnemyMovementState enemyMovementState)
    {
        switch (enemyMovementState)
        {
            case EnemyMovementState.normalMovement:
                //m_Rigidbody2D.velocity = new Vector2(m_PlayerBehaviour.m_Input.m_HorizontalAxis * m_PlayerBehaviour.m_PlayerData.m_MovementSpeed, m_Rigidbody2D.velocity.y);
                break;
            case EnemyMovementState.dashMovement:
                //m_Rigidbody2D.velocity = new Vector2(m_PlayerBehaviour.m_Input.m_HorizontalAxis * m_PlayerBehaviour.m_PlayerData.m_DashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case EnemyMovementState.directionalMovement:
                //m_Rigidbody2D.velocity = new Vector2(m_Direction * m_PlayerBehaviour.m_PlayerData.m_DashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case EnemyMovementState.fastDirectionalMovement:
                //m_Rigidbody2D.velocity = new Vector2(m_Direction * m_PlayerBehaviour.m_CobaltData.m_AirDashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case EnemyMovementState.noMovement:
                m_Rigidbody2D.velocity = Vector2.zero;
                break;
        }
        return enemyMovementState;
    }

    public EnemyAerialState SetAerialState(EnemyAerialState playerAerialState)
    {
        switch (playerAerialState)
        {
            case EnemyAerialState.fullGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y);
                m_Rigidbody2D.gravityScale = m_OriginalGravity;
                break;
            case EnemyAerialState.reducedGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y / 1.75f);
                m_Rigidbody2D.gravityScale = m_OriginalGravity;
                break;
            case EnemyAerialState.zeroGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y * 0f);
                m_Rigidbody2D.gravityScale = 0f;
                break;
        }
        return playerAerialState;
    }
    */
}
