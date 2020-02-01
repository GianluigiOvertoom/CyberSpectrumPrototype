using UnityEngine;
using System.Collections;

public interface IPlayerState
{
    void OnEnter();
    void HandleInput();
    void HandleBehaviour();
    void HandlePhysics();
    void OnExit();
}

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerController m_PlayerController { get; set; }
    public PlayerData m_PlayerData { get; set; }
    public InputControlles m_Input { get; set; }
    public PlayerPhysicsBehaviour m_PlayerPhysicsBehaviour { get; set; }
    public GroundCheckBehaviour m_GroundCheckBehaviour { get; set; }
    public Animator m_Animator { get; set; }
    public PlayerHitBoxSpawner m_PlayerHitBoxSpawner { get; set; }
    public bool m_CanTurn { get; set; }
    public bool m_RemoveVelocityCap { get; set; }
    public bool m_CanJump { get; set; }
    public bool m_CanChangeColor { get; set; }
    public bool m_CanChangeCharacter { get; set; }
    public bool m_WasGrounded { get; set; }

    private BoxCollider2D m_BoxCollider2D;    
    private SpriteRenderer m_SpriteRenderer;
    private IPlayerState m_PlayerState;
    private bool m_revertCollider;
    private Vector2 m_OriginalColliderSize;
    private Vector2 m_OriginalColliderOffset;

    /*
    public PlayerSpecialEffects _playerSpecialEffects;
    */

    //Get Player specific properties
    public CobaltData m_CobaltData { get; set; }
    public CobaltBehaviour m_CobaltBehaviour { get; set; }
    private CobaltBulletController m_CobaltBulletController;
    
    private void Awake()
    {
        m_PlayerController = GameObject.FindObjectOfType<PlayerController>();
        m_PlayerPhysicsBehaviour = gameObject.AddComponent<PlayerPhysicsBehaviour>();
        m_PlayerData = m_PlayerController.m_PlayerData;
        m_Input = m_PlayerController.m_InputControlles;
        m_GroundCheckBehaviour = GetComponent<GroundCheckBehaviour>();
        m_Animator = GetComponentInChildren<Animator>();
        m_PlayerHitBoxSpawner = GameObject.FindObjectOfType<PlayerHitBoxSpawner>();
        m_CanTurn = true;
        m_CanJump = true;
        m_CanChangeColor = true;
        m_CanChangeCharacter = true;
        m_WasGrounded = true;
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_PlayerState = new PlayerStandingBehaviour(this);

        m_OriginalColliderSize = new Vector2(0.75f, 2.5f);
        m_OriginalColliderOffset = new Vector2(0f, -0.75f);

        m_CobaltBehaviour = new CobaltBehaviour();
        m_CobaltData = ScriptableObject.CreateInstance<CobaltData>();
        m_CobaltBulletController = GameObject.FindObjectOfType<CobaltBulletController>();
    }

    private void Update()
    {
        m_PlayerState.HandleBehaviour();
        m_PlayerState.HandleInput();
        m_PlayerState.HandlePhysics();

        if (m_Input.m_SwitchButtonDown && m_CanChangeCharacter)
        {
            if (m_PlayerData.m_ActiveCharacter.Equals(ActiveCharacter.cobalt))
            {
                m_PlayerData.m_ActiveCharacter = ActiveCharacter.crimson;
            }
            else
            {
                m_PlayerData.m_ActiveCharacter = ActiveCharacter.cobalt;
            }
        }

        switch (m_PlayerData.m_ActiveCharacter)
        {
            case ActiveCharacter.cobalt:
                m_Animator.SetLayerWeight(1, 0f);
                if (m_CobaltBehaviour.m_AllowShooting)
                {
                    m_CobaltBehaviour.HandleShooting(m_PlayerPhysicsBehaviour.m_Rigidbody2D.transform, m_PlayerPhysicsBehaviour.m_Direction,
                    m_Input.m_RangedAttackButton, m_CobaltData.m_ShootSpeed, m_CobaltBulletController);
                }                
                m_Animator.SetFloat("cobaltShootState", m_CobaltBehaviour.m_ShootState);
                if (m_Input.m_UtillityButtonDown)
                {
                    m_CobaltBulletController.SwitchPolar();
                }
                break;
            case ActiveCharacter.crimson:
                m_Animator.SetLayerWeight(1, 1f);
                break;
        }
        if (m_Input.m_UtillityButtonDown && m_CanChangeColor)
        {
            if (m_PlayerData.m_ActiveColor.Equals(ActiveColor.normal))
            {
                m_PlayerData.m_ActiveColor = ActiveColor.alt;
            }
            else
            {
                m_PlayerData.m_ActiveColor = ActiveColor.normal;
            }
        }
        m_Animator.SetFloat("activeColor", (float)m_PlayerData.m_ActiveColor);
    }

    private void FixedUpdate()
    {
        m_PlayerState.HandlePhysics();
        m_PlayerPhysicsBehaviour.HandlePlayerDirection(m_SpriteRenderer, m_CanTurn);
        m_PlayerPhysicsBehaviour.HandleSpeedLimit(m_PlayerData.m_VecolityCap, m_RemoveVelocityCap);
    }

    public void SwitchState(IPlayerState newPlayerState)
    {
        if (newPlayerState.Equals(null))
            return;
        m_PlayerState.OnExit();
        m_PlayerState = newPlayerState;
        m_PlayerState.OnEnter();
    }

    public void MorphCollider(Vector2 newSize, Vector2 newOffset)
    {
        m_BoxCollider2D.size = newSize;
        m_BoxCollider2D.offset = newOffset;
    }

    public void RevertCollider()
    {
        m_BoxCollider2D.size = m_OriginalColliderSize;
        m_BoxCollider2D.offset = m_OriginalColliderOffset;
    }

    public void BufferJump()
    {
        StartCoroutine(JumpSaver());        
    }

    private IEnumerator JumpSaver()
    {
        yield return new WaitForSeconds(m_PlayerData.m_BufferJumpTime);
        if (!m_GroundCheckBehaviour.m_OnGround)
        {
            m_CanJump = false;
        }
        else
        {
            m_CanJump = true;
        }        
    }
}
