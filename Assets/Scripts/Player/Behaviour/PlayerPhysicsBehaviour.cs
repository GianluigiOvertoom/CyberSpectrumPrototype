using UnityEngine;

public enum PlayerMovementState
{
    normalMovement,
    dashMovement,
    directionalMovement,
    fastDirectionalMovement,
    noMovement
}

public enum PlayerAerialState
{
    fullGravity,
    reducedGravity,
    zeroGravity
}

public class PlayerPhysicsBehaviour : MonoBehaviour
{
    public float m_Direction { get; set; }
    public Rigidbody2D m_Rigidbody2D { get; set; }

    private PlayerBehaviour m_PlayerBehaviour;
    private float m_OriginalGravity;
    private float m_reducedGravity;

    private void Awake()
    {
        m_Direction = 1f;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_PlayerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void Start()
    {
        m_OriginalGravity = m_PlayerBehaviour.m_PlayerData.m_OriginalGravity;
        m_reducedGravity = m_PlayerBehaviour.m_PlayerData.m_ReducedGravity;
    }

    public void HandlePlayerDirection(SpriteRenderer spriteRenderer, bool canTurn)
    {
        if (canTurn)
        {
            if (m_PlayerBehaviour.m_Input.m_HorizontalAxis > 0)
            {
                m_Direction = 1f;
                spriteRenderer.flipX = false;
            }
            else if (m_PlayerBehaviour.m_Input.m_HorizontalAxis < 0)
            {
                m_Direction = -1f;
                spriteRenderer.flipX = true;
            }
        }
    }

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

    public PlayerMovementState SetMovementState(PlayerMovementState playerMovementState)
    {
        switch (playerMovementState)
        {
            case PlayerMovementState.normalMovement:
                m_Rigidbody2D.velocity = new Vector2(m_PlayerBehaviour.m_Input.m_HorizontalAxis * m_PlayerBehaviour.m_PlayerData.m_MovementSpeed, m_Rigidbody2D.velocity.y);
                break;
            case PlayerMovementState.dashMovement:
                m_Rigidbody2D.velocity = new Vector2(m_PlayerBehaviour.m_Input.m_HorizontalAxis * m_PlayerBehaviour.m_PlayerData.m_DashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case PlayerMovementState.directionalMovement:
                m_Rigidbody2D.velocity = new Vector2(m_Direction * m_PlayerBehaviour.m_PlayerData.m_DashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case PlayerMovementState.fastDirectionalMovement:
                m_Rigidbody2D.velocity = new Vector2(m_Direction * m_PlayerBehaviour.m_CobaltData.m_AirDashSpeed, m_Rigidbody2D.velocity.y);
                break;
            case PlayerMovementState.noMovement:
                m_Rigidbody2D.velocity = Vector2.zero;
                break;
        }
        return playerMovementState;
    }

    public PlayerAerialState SetAerialState(PlayerAerialState playerAerialState)
    {
        switch (playerAerialState)
        {
            case PlayerAerialState.fullGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y);
                m_Rigidbody2D.gravityScale = m_OriginalGravity;
                break;
            case PlayerAerialState.reducedGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y / 1.75f);
                m_Rigidbody2D.gravityScale = m_OriginalGravity;
                break;
            case PlayerAerialState.zeroGravity:
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y * 0f);
                m_Rigidbody2D.gravityScale = 0f;
                break;
        }
        return playerAerialState;
    }
}
