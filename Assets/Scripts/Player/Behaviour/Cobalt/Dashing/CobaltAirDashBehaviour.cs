using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaltAirDashBehaviour : IPlayerState
{
    private float m_dashTime;
    private PlayerBehaviour m_PlayerBehaviour;

    public CobaltAirDashBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("AirDash");
        m_PlayerBehaviour.m_CanTurn = false;
        m_PlayerBehaviour.m_RemoveVelocityCap = true;
        m_PlayerBehaviour.m_CanJump = false;
        m_dashTime = 0f;
        m_PlayerBehaviour.m_CobaltBehaviour.RemoveCharge();
        m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = false;
        //m_PlayerBehaviour.MorphCollider(new Vector2(2.5f, 0.75f), new Vector2(0f, -0.4f));
    }
    public void HandleInput()
    {
    }
    public void HandleBehaviour()
    {
        if (m_dashTime >= m_PlayerBehaviour.m_CobaltData.m_AirDashTimeLimit || !m_PlayerBehaviour.m_Input.m_DashButton)
        {
            m_PlayerBehaviour.SwitchState(new CobaltPostAirDash(m_PlayerBehaviour));
        }
        else
        {
            m_dashTime += Time.deltaTime;
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.fastDirectionalMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.zeroGravity);
    }
    public void OnExit()
    {
        m_dashTime = 0f;
        //m_PlayerBehaviour.RevertCollider();
    }
}
