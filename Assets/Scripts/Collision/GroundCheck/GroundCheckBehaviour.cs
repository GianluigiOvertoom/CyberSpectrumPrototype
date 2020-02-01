using System.Collections;
using UnityEngine;

public class GroundCheckBehaviour : MonoBehaviour
{
    public bool m_OnGround { get; set; }
    public bool m_UnderCeiling { get; set; }
    public bool m_OnPlatform { get; set; }
    public bool m_OnSlope { get; set; }
    public bool m_FallThroughPlatform { get; set; }
    public GroundType m_ColliderCheck;

    private Vector2 m_GroundCheck;
    private Vector2 m_CeilingCheck;
    private LayerMask m_OriginalPlatformLayer;
    private float m_FallTimer = 0.2f;
    private int m_TargetLayer;

    

    private void Awake()
    {
        m_TargetLayer = gameObject.layer;
        m_OriginalPlatformLayer = m_ColliderCheck.m_PlatformLayer;        
    }

    private void Update()
    {
        m_GroundCheck = new Vector2(transform.position.x, transform.position.y + m_ColliderCheck.m_GroundCheckDistance);
        m_CeilingCheck = new Vector2(transform.position.x, transform.position.y + m_ColliderCheck.m_CeilingCheckDistance);

        m_OnGround = Physics2D.OverlapBox(m_GroundCheck, m_ColliderCheck.m_CheckGroundRadius, 0, m_ColliderCheck.m_GroundLayers);
        m_UnderCeiling = Physics2D.OverlapBox(m_CeilingCheck, m_ColliderCheck.m_CheckCeilingRadius, 0, m_ColliderCheck.m_CeilingLayers);
        m_OnPlatform = Physics2D.OverlapBox(m_GroundCheck, m_ColliderCheck.m_CheckGroundRadius, 0, m_ColliderCheck.m_PlatformLayer);
        if (m_OnPlatform)
        {
            m_OnGround = true;
        }
    }

    private IEnumerator FallThroughPlatform()
    {
        Physics2D.IgnoreLayerCollision(m_TargetLayer, LayerMask.NameToLayer("Platform"), true);
        m_ColliderCheck.m_PlatformLayer = 0;//Sets LayerMask to nothing
        yield return new WaitForSeconds(m_FallTimer);
        Physics2D.IgnoreLayerCollision(m_TargetLayer, LayerMask.NameToLayer("Platform"), false);
        m_ColliderCheck.m_PlatformLayer = m_OriginalPlatformLayer;
    }

    public void FallTroughPlatform()
    {
        StartCoroutine(FallThroughPlatform());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(m_GroundCheck, m_ColliderCheck.m_CheckGroundRadius);
    }
}
