public class PlayerRunningBehaviour : IPlayerState
{
    private PlayerBehaviour m_PlayerBehaviour;

    public PlayerRunningBehaviour(PlayerBehaviour playerBehaviour)
    {
        m_PlayerBehaviour = playerBehaviour;
    }

    public void OnEnter()
    {
        m_PlayerBehaviour.m_Animator.Play("ToRunning", 0);
        m_PlayerBehaviour.m_Animator.Play("ToRunning", 1);
        m_PlayerBehaviour.m_CanTurn = true;
        m_PlayerBehaviour.m_RemoveVelocityCap = false;
        m_PlayerBehaviour.m_CanJump = true;
        m_PlayerBehaviour.m_CanChangeCharacter = true;
        m_PlayerBehaviour.m_CanChangeColor = true;

        m_PlayerBehaviour.m_CobaltBehaviour.RefillCharges(m_PlayerBehaviour.m_CobaltData.m_AirDashChargeCapacity);

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_PlayerBehaviour.m_CobaltBehaviour.m_AllowShooting = true;
                m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint = CobaltOriginPoint.running;
                break;
        }
    }

    public void HandleInput()
    {
        if (m_PlayerBehaviour.m_Input.m_HorizontalAxis.Equals(0))
        {
            m_PlayerBehaviour.SwitchState(new PlayerStandingBehaviour(m_PlayerBehaviour));
        }

        if (m_PlayerBehaviour.m_Input.m_JumpButtonDown && m_PlayerBehaviour.m_CanJump)
        {
            if (m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnPlatform && m_PlayerBehaviour.m_Input.m_VerticalAxis < 0)
            {
                m_PlayerBehaviour.SwitchState(new PlayerFallingBehaviour(m_PlayerBehaviour));
                m_PlayerBehaviour.m_GroundCheckBehaviour.FallTroughPlatform();
                m_PlayerBehaviour.m_CanJump = false;
            }
            else
            {
                m_PlayerBehaviour.SwitchState(new PlayerJumpingBehaviour(m_PlayerBehaviour));
            }
        }
        if (m_PlayerBehaviour.m_Input.m_DashButtonDown)
        {
            m_PlayerBehaviour.SwitchState(new PlayerDashBehaviour(m_PlayerBehaviour));
        }

        if (m_PlayerBehaviour.m_Input.m_MeleeAttackButtonDown)
        {
            m_PlayerBehaviour.SwitchState(new PlayerGroundedMelee1(m_PlayerBehaviour));
        }
    }
    public void HandleBehaviour()
    {
        if (!m_PlayerBehaviour.m_GroundCheckBehaviour.m_OnGround)
        {
            m_PlayerBehaviour.SwitchState(new PlayerFallingBehaviour(m_PlayerBehaviour));
            m_PlayerBehaviour.BufferJump();
        }
    }
    public void HandlePhysics()
    {
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetMovementState(PlayerMovementState.normalMovement);
        m_PlayerBehaviour.m_PlayerPhysicsBehaviour.SetAerialState(PlayerAerialState.fullGravity);
    }
    public void OnExit()
    {
        m_PlayerBehaviour.m_WasGrounded = true;
    }
}
