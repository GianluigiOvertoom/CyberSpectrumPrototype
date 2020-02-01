using UnityEngine;

public enum CobaltOriginPoint
{
    standing,
    running,
    dashing,
    other
}

public class CobaltBehaviour
{
    public float m_AirDashCharges { get; set; }
    public CobaltOriginPoint m_CobaltOriginPoint { get; set; }
    public float m_ShootState { get; set; }
    public bool m_AllowShooting { get; set; }

    private CobaltData m_CobaltData;
    private float m_ShotStateLimit = 3f;
    private float m_MaxShotState = 5f;
    private CobaltBulletController m_CobaltBulletController;

    private void ShootShot(CobaltBulletController cobaltBulletController)
    {
        cobaltBulletController.OnSpawnBullet();
    }

    public void RemoveCharge()
    {
        m_AirDashCharges -= 1f;
    }

    public void RefillCharges(float airDashCapacity)
    {
        m_AirDashCharges = airDashCapacity;
    }

    public void HandleShooting(Transform transform, float direction, bool attackButton, float shotSpeed, CobaltBulletController cobaltBulletController)
    {
        if (m_ShootState.Equals(0) && attackButton 
            || m_ShootState >= m_ShotStateLimit && attackButton)
        {
            m_ShootState = 1f;
            ShootShot(cobaltBulletController);
        }

        if (!m_ShootState.Equals(0) && m_ShootState < m_MaxShotState)
        {
            m_ShootState += (shotSpeed * Time.deltaTime);
        }

        if (m_ShootState >= m_MaxShotState)
        {
            switch (attackButton)
            {
                case true:
                    m_ShootState = 1f;
                    break;
                case false:
                    m_ShootState = 0f;
                    break;
            }           
        }
    }
}
