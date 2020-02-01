using UnityEngine;

public class CobaltData : ScriptableObject
{
    public float m_AirDashSpeed;
    public float m_AirDashTimeLimit;

    public float m_ShootSpeed;
    public float m_AirDashChargeCapacity;
    public float m_PreAirDashTimeLimit;
    public float m_PolarTimeLimit;

    private void Awake()
    {
        m_AirDashSpeed = 40f;
        m_AirDashTimeLimit = 0.5f;
        m_ShootSpeed = 10f;
        m_AirDashChargeCapacity = 2f;
        m_PreAirDashTimeLimit = 0.1f;
        m_PolarTimeLimit = 6f;
    }
}
