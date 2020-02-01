using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaltDiveBehaviour : IPlayerState
{
    /*
    [SerializeField] private GameObject _hitbox;
    private Vector2 _originalColliderSize;
    private Vector2 _originalOffset;
    */
    private float m_dashTime;
    private PlayerBehaviour m_PlayerBehaviour;

    public CobaltDiveBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("DiveDash");
        m_PlayerBehaviour.m_CanTurn = false;
        m_PlayerBehaviour.m_RemoveVelocityCap = true;
        m_PlayerBehaviour.m_CanJump = false;
        m_dashTime = 0f;
        m_PlayerBehaviour.m_CobaltBehaviour.RemoveCharge();
        m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = false;
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
        if (m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnGround)
        {
            m_PlayerBehaviour.SwitchState(new PlayerStandingBehaviour(m_PlayerBehaviour));
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.fastDirectionalMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Rigidbody2D.velocity = new Vector2(m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Rigidbody2D.velocity.x, -m_PlayerBehaviour.m_CobaltData.m_AirDashSpeed);
    }
    public void OnExit()
    {
        m_dashTime = 0f;
    }
}
