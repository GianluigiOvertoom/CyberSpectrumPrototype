using UnityEngine;

public class PlayerDashJumpBehaviour : IPlayerState
{
    private float m_JumpTime;
    private PlayerBehaviour m_PlayerBehaviour;

    public PlayerDashJumpBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("ToJumping", 0);
        m_PlayerBehaviour.m_Animator.Play("ToJumping", 1);
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = false;
        m_PlayerBehaviour.m_CanChangeCharacter = true;
        m_PlayerBehaviour.m_CanChangeColor = true;
        m_JumpTime = 0f;

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = true;
                m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint = CobaltOriginPoint.other;
                break;
        }
    }
    public void HandleInput()
    {
        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                if (m_PlayerBehaviour.m_Input.m_DashButtonDown && m_PlayerBehaviour.m_CobaltBehaviour.m_AirDashCharges > 0)
                {
                    m_PlayerBehaviour.SwitchState(new CobaltPreAirDash(m_PlayerBehaviour));
                }
                break;
            case ActiveCharacter.crimson:
                break;
        }
    }
    public void HandleBehaviour()
    {
        if (m_JumpTime >= m_PlayerBehaviour.m_PlayerData.m_JumpTimeLimit || !m_PlayerBehaviour.m_Input.m_JumpButton)
        {
            m_PlayerBehaviour.SwitchState(new PlayerDashFallBehaviour(m_PlayerBehaviour));
        }
        else
        {
            m_JumpTime += Time.deltaTime;
            m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Rigidbody2D.velocity = Vector2.up * m_PlayerBehaviour.m_PlayerData.m_JumpSpeed;
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.dashMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
    }
    public void OnExit()
    {
        m_JumpTime = 0f;
    }
}
