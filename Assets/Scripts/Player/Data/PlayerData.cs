using UnityEngine;

public enum ActiveCharacter
{
    cobalt,
    crimson
}

public enum ActiveColor
{
    normal,
    alt
}

public class PlayerData : ScriptableObject
{
    public ActiveCharacter m_ActiveCharacter;
    public ActiveColor m_ActiveColor;
    public Vector2 m_SpawnPosition;
    public int m_OriginalGravity;
    public float m_ReducedGravity;
    public float m_MovementSpeed;
    public float m_DashSpeed;   
    public float m_JumpSpeed;
    public float m_VecolityCap;
    public float m_JumpTimeLimit;
    public float m_BufferJumpTime;
    public float m_DashTimeLimit;
    
    private void Awake()
    {
        m_OriginalGravity = 9;
        m_ReducedGravity = 1.75f;
        m_MovementSpeed = 10f;
        m_DashSpeed = 20f;       
        m_JumpSpeed = 21.75f;
        m_VecolityCap = 27.5f;
        m_JumpTimeLimit = 0.2f;
        m_BufferJumpTime = 0.1f;
        m_DashTimeLimit = 0.75f;
    }    
}
