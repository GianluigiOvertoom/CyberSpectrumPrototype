using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedMelee1 : IPlayerState
{
    private PlayerBehaviour m_PlayerBehaviour;

    public PlayerGroundedMelee1(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("GroundedMelee", 0);
        m_PlayerBehaviour.m_Animator.Play("GroundedMelee", 1);
        m_PlayerBehaviour.m_CanTurn = false;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = false;
        m_PlayerBehaviour.m_CanChangeCharacter = false;
        m_PlayerBehaviour.m_CanChangeColor = false;

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = false;
                m_PlayerBehaviour.m_PlayerHitBoxSpawner.SetNewHitboxCoordiates(new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (1.25f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + -0.2f), new Vector2(4.5f, 3.5f));
                break;
            case ActiveCharacter.crimson:
                m_PlayerBehaviour.m_PlayerHitBoxSpawner.SetNewHitboxCoordiates(new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (1f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + -0.25f), new Vector2(6f, 3.5f));
                break;
        }
        
    }
    public void HandleInput()
    {
    }
    public void HandleBehaviour()
    {
        if (m_PlayerBehaviour.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= m_PlayerBehaviour.m_Animator.GetCurrentAnimatorClipInfoCount(0))
        {
            if (m_PlayerBehaviour.m_Input.m_HorizontalAxis.Equals(0))
            {
                m_PlayerBehaviour.SwitchState(new PlayerStandingBehaviour(m_PlayerBehaviour));
            }
            else if (!m_PlayerBehaviour.m_Input.m_HorizontalAxis.Equals(0))
            {
                m_PlayerBehaviour.SwitchState(new PlayerRunningBehaviour(m_PlayerBehaviour));
            }
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.noMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
    }
    public void OnExit()
    {
        m_PlayerBehaviour.m_PlayerHitBoxSpawner.DisableCollider();
    }
}
