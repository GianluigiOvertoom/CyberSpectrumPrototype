using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashBehaviour : IPlayerState
{
    private PlayerBehaviour m_PlayerBehaviour;

    public PlayerDashBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    private float m_DashTime;

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("ToGroundDash", 0);
        m_PlayerBehaviour.m_Animator.Play("ToGroundDash", 1);
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = true;
        m_PlayerBehaviour.m_CanChangeCharacter = false;
        m_PlayerBehaviour.m_CanChangeColor = true;
        m_DashTime = 0f;

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint = CobaltOriginPoint.dashing;
                m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = true;
                break;
            case ActiveCharacter.crimson:
                break;
        }
    }

    public void HandleInput()
    {
        if (m_PlayerBehaviour.m_Input.m_JumpButtonDown && m_PlayerBehaviour.m_CanJump)
        {
            if (m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnPlatform && m_PlayerBehaviour.m_Input.m_VerticalAxis < 0)
            {
                m_PlayerBehaviour.SwitchState(new PlayerDashFallBehaviour(m_PlayerBehaviour));
                m_PlayerBehaviour.m_GroundCheckBehaviour.FallTroughPlatform();
                m_PlayerBehaviour.m_CanJump = false;
            }
            else
            {
                m_PlayerBehaviour.SwitchState(new PlayerDashJumpBehaviour(m_PlayerBehaviour));
            }
        }
    }
    public void HandleBehaviour()
    {
        if (!m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnGround)
        {
            m_PlayerBehaviour.SwitchState(new PlayerDashFallBehaviour(m_PlayerBehaviour));
            m_PlayerBehaviour.BufferJump();
        }
        if (m_DashTime >= m_PlayerBehaviour.m_PlayerData.m_DashTimeLimit || !m_PlayerBehaviour.m_Input.m_DashButton)
        {
            if (m_PlayerBehaviour.m_Input.m_HorizontalAxis.Equals(0))
            {
                m_PlayerBehaviour.SwitchState(new PlayerStandingBehaviour(m_PlayerBehaviour));
            }
            else
            {
                m_PlayerBehaviour.SwitchState(new PlayerRunningBehaviour(m_PlayerBehaviour));
            }
        }
        else
        {
            m_DashTime += Time.deltaTime;
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.directionalMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
    }
    public void OnExit()
    {
        m_DashTime = 0f;
    }
}
