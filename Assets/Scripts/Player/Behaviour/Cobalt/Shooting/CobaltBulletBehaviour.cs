using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletState
{
    void OnEnter();
    void HandleBehaviour();
    void OnExit();
}

public class CobaltBulletBehaviour : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D { get; set; }
    public float m_BulletDirection { get; set; }
    public ParabolaController m_ParabolaController { get; set; }
    public LayerMask m_LayerMask { get; set; }
    public Animator m_Animator { get; set; }
    public SpriteRenderer m_SpriteRenderer { get; set; }
    public TrailRenderer m_TrailRenderer { get; set; }
    public float m_BulletSpeed;
    

    private IBulletState m_BulletState;
    private CobaltBulletController m_BulletController;
    private PlayerBehaviour m_PlayerBehaviour;
    
    
    /*
    public GameObject _polarStorage;

    private float _parabolaDistanceX;
    private float _parabolaDistanceY;
    private float _xDifference;
    private float _yDifference;
    */

    private void Awake()
    {
        m_BulletState = new CobaltNormalBulletBehaviour(this);
        m_BulletController = GameObject.FindObjectOfType<CobaltBulletController>();
        m_PlayerBehaviour = GameObject.FindObjectOfType<PlayerBehaviour>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_LayerMask = gameObject.layer;
        m_Animator = GetComponentInChildren<Animator>();
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_TrailRenderer = GetComponentInChildren<TrailRenderer>();        
        
        m_BulletSpeed = 50f;
        
        m_ParabolaController = GetComponent<ParabolaController>();
        m_ParabolaController.ParabolaRoot = m_BulletController.m_ParabolaRoot.gameObject;
        m_ParabolaController.Speed = m_BulletSpeed;
        m_ParabolaController.enabled = false;
    }

    private void OnEnable()
    {
        OnSpawn();
        m_BulletState.OnEnter();
    }

    private void Update()
    {
        m_BulletState.HandleBehaviour();
    }

    private void OnDisable()
    {
        m_TrailRenderer.Clear();
        m_BulletState.OnExit();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeactivateBullet();
    }

    public void OnSpawn()
    {
        m_BulletDirection = m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction;
        m_TrailRenderer.startColor = m_BulletController.m_BulletColor;
        m_Animator.SetFloat("ActiveColor", (float)m_BulletController.m_BulletPolar);

        switch (m_BulletController.m_BulletType)
        {
            case BulletType.normal:
                m_BulletState = new CobaltNormalBulletBehaviour(this);
                break;
            case BulletType.chasing:
                m_BulletState = new CobaltChasingBulletBehaviour(this);                
                break;
        }
    }

    public void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
}

