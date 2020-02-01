public class PlayerFallingBehaviour : IPlayerState
{
    private PlayerBehaviour m_PlayerBehaviour;

    public PlayerFallingBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanChangeColor = true;
        m_PlayerBehaviour.m_CanChangeCharacter = true;

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                if (m_PlayerBehaviour.m_CobaltBehaviour.m_ShootState.Equals(0))
                {
                    m_PlayerBehaviour.m_Animator.Play("ToFalling", 0);
                    m_PlayerBehaviour.m_Animator.Play("ToFalling", 1);
                    m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint = CobaltOriginPoint.other;
                }
                else
                {
                    m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint = CobaltOriginPoint.other;
                    return;
                }
                break;
            case ActiveCharacter.crimson:
                m_PlayerBehaviour.m_Animator.Play("ToFalling", 0);
                m_PlayerBehaviour.m_Animator.Play("ToFalling", 1);
                break;
        }
    }

    public void HandleInput()
    {
        if (m_PlayerBehaviour.m_Input.m_JumpButtonDown && m_PlayerBehaviour.m_CanJump)
        {
            m_PlayerBehaviour.SwitchState(new PlayerJumpingBehaviour(m_PlayerBehaviour));
        }

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = true;
                if (m_PlayerBehaviour.m_Input.m_DashButtonDown && m_PlayerBehaviour.m_CobaltBehaviour.m_AirDashCharges > 0)
                {
                    m_PlayerBehaviour.SwitchState(new CobaltPreAirDash(m_PlayerBehaviour));
                }
                if (!m_PlayerBehaviour.m_CobaltBehaviour.m_ShootState.Equals(0))
                {
                    m_PlayerBehaviour.m_Animator.Play("Falling");
                }
                break;
            case ActiveCharacter.crimson:
                break;
        }
    }
    public void HandleBehaviour()
    {
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
        m_PlayerBehaviour.m_WasGrounded = false;
    }
}
