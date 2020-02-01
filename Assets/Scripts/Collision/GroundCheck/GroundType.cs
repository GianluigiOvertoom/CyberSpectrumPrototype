using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GroundType : ScriptableObject
{
    public float m_GroundCheckDistance;
    public float m_CeilingCheckDistance;

    public LayerMask m_GroundLayers;
    public LayerMask m_CeilingLayers;
    public LayerMask m_PlatformLayer;

    public Vector2 m_CheckGroundRadius;
    public Vector2 m_CheckCeilingRadius;
}
