using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PolarType
{
    proton,
    neutron
}

public class PolarBehaviour : MonoBehaviour
{
    public PolarType m_PolarType;

    private CobaltBulletController m_CobaltBulletController;
    private CobaltData m_CobaltData;

    private float m_TimeLimit;
    private float m_Timer;

    private void Awake()
    {
        m_CobaltBulletController = GameObject.FindObjectOfType<CobaltBulletController>();        
    }

    private void Start()
    {
        m_CobaltData = GameObject.FindObjectOfType<PlayerBehaviour>().m_CobaltData;
        m_TimeLimit = m_CobaltData.m_PolarTimeLimit;
        m_Timer = 0f;
    }

    private void OnEnable()
    {        
        switch (m_PolarType)
        {
            case PolarType.neutron:
                m_CobaltBulletController.AddNeutronMark(this.gameObject);
                break;
            case PolarType.proton:
                m_CobaltBulletController.AddProtonMark(this.gameObject);
                break;
        }
    }

    private void OnDisable()
    {
        m_Timer = 0f;
        switch (m_PolarType)
        {
            case PolarType.neutron:
                m_CobaltBulletController.RemoveNeutronMark(this.gameObject);
                break;
            case PolarType.proton:
                m_CobaltBulletController.RemoveProtonMark(this.gameObject);
                break;
        }
    }

    public void DisableObject()
    {
        if (transform.parent != null)
        {
            GetComponentInParent<MoveableObject>().RemovePolar();
            transform.parent = null;
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        if (m_Timer.Equals(0))
        {
            GetComponentInParent<MoveableObject>().AddPolar(this);           
        }
        if (m_Timer >= m_TimeLimit)
        {
            DisableObject();
        }
        else
        {
            m_Timer += Time.deltaTime;
        }
    }
}
