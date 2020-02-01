using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaltPostAirDash : IPlayerState
{
    private float m_recoverTime;
    private float m_recoverTimeLimit;
    private PlayerBehaviour m_PlayerBehaviour;

    public CobaltPostAirDash(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("PostAirDash");
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = false;
        m_recoverTime = 0f;
        m_recoverTimeLimit = m_PlayerBehaviour.m_Animator.GetCurrentAnimatorStateInfo(0).length;
        m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = false;
    }
    public void HandleInput()
    {
        if (m_PlayerBehaviour.m_Input.m_DashButtonDown && m_PlayerBehaviour.m_CobaltBehaviour.m_AirDashCharges > 0)
        {
            m_PlayerBehaviour.SwitchState(new CobaltPreAirDash(m_PlayerBehaviour));
        }
    }
    public void HandleBehaviour()
    {
        if (m_recoverTime >= m_recoverTimeLimit)
        {
            m_PlayerBehaviour.SwitchState(new PlayerFallingBehaviour(m_PlayerBehaviour));
        }
        else
        {
            m_recoverTime += Time.deltaTime;
        }
        if (m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnGround)
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
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.normalMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
    }
    public void OnExit()
    {
        m_recoverTime = 0f;
    }
}
