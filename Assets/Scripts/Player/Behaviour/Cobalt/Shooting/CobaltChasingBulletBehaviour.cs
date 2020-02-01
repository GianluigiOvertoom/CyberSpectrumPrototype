using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaltChasingBulletBehaviour : IBulletState
{
    private float m_CurrentFlightTime;
    private float m_FlightTimer = 1.5f;
    private CobaltBulletBehaviour m_CobaltBulletBehaviour;

    public CobaltChasingBulletBehaviour(CobaltBulletBehaviour cobaltBulletBehaviour)
    {
        m_CobaltBulletBehaviour = cobaltBulletBehaviour;
    }

    public void OnEnter()
    {
        /*
        m_CobaltBulletBehaviour.m_Animator.enabled = false;
        Physics2D.IgnoreLayerCollision(m_CobaltBulletBehaviour.m_LayerMask, LayerMask.NameToLayer("Ground"), true);
        m_CobaltBulletBehaviour.m_ParabolaController.enabled = true;

        if (!m_CobaltBulletBehaviour.m_ParabolaController.Autostart)
        {
            m_CobaltBulletBehaviour.m_ParabolaController.FollowParabola();
        }
        */
        //Debug.Log(m_CobaltBulletBehaviour.m_Animator.enabled);
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
        m_CobaltBulletBehaviour.m_ParabolaController.Autostart = false;
        m_CobaltBulletBehaviour.m_ParabolaController.enabled = false;
        m_CobaltBulletBehaviour.m_SpriteRenderer.sprite = null;
    }
}
