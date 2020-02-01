using UnityEngine;

public class CobaltNormalBulletBehaviour : IBulletState
{
    private float m_CurrentFlightTime;
    private float m_FlightTimer = 1f;
    private CobaltBulletBehaviour m_CobaltBulletBehaviour;

    public CobaltNormalBulletBehaviour(CobaltBulletBehaviour cobaltBulletBehaviour)
    {
        m_CobaltBulletBehaviour = cobaltBulletBehaviour;
    }

    public void OnEnter()
    {
        m_CobaltBulletBehaviour.m_Animator.enabled = true;
        Physics2D.IgnoreLayerCollision(m_CobaltBulletBehaviour.m_LayerMask, LayerMask.NameToLayer("Ground"), false);
        m_CobaltBulletBehaviour.m_Rigidbody2D.velocity = new Vector2(m_CobaltBulletBehaviour.m_BulletSpeed * m_CobaltBulletBehaviour.m_BulletDirection, 0f);
    }

    public void HandleBehaviour()
    {
        if (m_CurrentFlightTime >= m_FlightTimer)
        {
            m_CobaltBulletBehaviour.DeactivateBullet();
        }
        else
        {            
            m_CurrentFlightTime += Time.deltaTime;
        }        
    }

    public void OnExit()
    {
        m_CurrentFlightTime = 0f;
        m_CobaltBulletBehaviour.m_SpriteRenderer.sprite = null;
    }
}
