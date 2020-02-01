using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaltPreAirDash : IPlayerState
{
    private float m_PreAirDashTime;
    private PlayerBehaviour m_PlayerBehaviour;

    public CobaltPreAirDash(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("ToAirDash");
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = false;
        m_PreAirDashTime = 0f;
        m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = false;
    }
    public void HandleInput()
    {
        if (m_PreAirDashTime >= m_PlayerBehaviour.m_CobaltData.m_PreAirDashTimeLimit)
        {
            if (m_PlayerBehaviour.m_Input.m_VerticalAxis < 0)
            {
                m_PlayerBehaviour.SwitchState(new CobaltDiveBehaviour(m_PlayerBehaviour));
            }
            else
            {
                m_PlayerBehaviour.SwitchState(new CobaltAirDashBehaviour(m_PlayerBehaviour));
            }
        }
        else
        {
            m_PreAirDashTime += Time.deltaTime;
        }        
    }
    public void HandleBehaviour()
    {
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.noMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.zeroGravity);
    }
    public void OnExit()
    {
        m_PreAirDashTime = 0f;
    }
}
