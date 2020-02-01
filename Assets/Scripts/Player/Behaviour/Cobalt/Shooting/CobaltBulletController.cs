using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    normal,
    chasing
}

public enum BulletPolar
{
    Neutron,
    Proton
}

public class CobaltBulletController : MonoBehaviour
{
    public BulletPolar m_BulletPolar { get; set; }
    public BulletType m_BulletType { get; set; }
    public Color m_BulletColor { get; set; }
    public CobaltBulletParabolaRoot m_ParabolaRoot { get; set; }

    public List<GameObject> m_PositiveMarks;
    public List<GameObject> m_NegativeMarks;

    private CreatePool m_playerPool;
    private Vector2 m_GunOrigin;
    private PlayerBehaviour m_PlayerBehaviour;

    private void Awake()
    {
        m_playerPool = GetComponent<CreatePool>();
        m_ParabolaRoot = GetComponentInChildren<CobaltBulletParabolaRoot>();        
    }

    private void Start()
    {
        m_PlayerBehaviour = GameObject.FindObjectOfType<PlayerBehaviour>();
    }

    public void OnSpawnBullet()
    {
        switch (m_PlayerBehaviour.m_CobaltBehaviour.m_CobaltOriginPoint)
        {
            case CobaltOriginPoint.standing:
                m_GunOrigin = new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (1.3f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + 0.3f);
                break;
            case CobaltOriginPoint.running:
                m_GunOrigin = new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (1.9f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + 0.3f);
                break;
            case CobaltOriginPoint.dashing:
                m_GunOrigin = new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (2f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + 0.3f);
                break;
            case CobaltOriginPoint.other:
                m_GunOrigin = new Vector2(m_PlayerBehaviour.gameObject.transform.position.x + (1.75f * m_PlayerBehaviour.m_PlayerPhysicsBehaviour.m_Direction),
                    m_PlayerBehaviour.gameObject.transform.position.y + 0.4f);
                break;
        }

        switch (m_PlayerBehaviour.m_PlayerData.m_ActiveColor)
        {
            case ActiveColor.normal:
                m_BulletColor = new Color(0, 0.98f, 1f);
                if (m_NegativeMarks.Count != 0)
                {
                    m_BulletType = BulletType.chasing;
                }
                else
                {
                    m_BulletType = BulletType.normal;
                }
                break;
            case ActiveColor.alt:
                m_BulletColor = new Color(1f, 0.45f, 0.4f);
                if (m_PositiveMarks.Count != 0)
                {
                    m_BulletType = BulletType.chasing;
                }
                else
                {
                    m_BulletType = BulletType.normal;
                }
                break;
        }
        switch (m_BulletType)
        {
            case BulletType.normal:
                m_playerPool.m_ObjectPool.SpawnFromPool("CobaltBullet", m_GunOrigin, Quaternion.identity);
                break;
            case BulletType.chasing:
                m_ParabolaRoot.m_ParabolaOrigin.transform.position = m_GunOrigin;
                if (m_PlayerBehaviour.m_PlayerData.m_ActiveColor.Equals(ActiveColor.normal))
                {
                    SpawnChasingBullet(m_NegativeMarks);
                }
                else
                {
                    SpawnChasingBullet(m_PositiveMarks);                    
                }
                break;
        }
    }

    public void SwitchPolar()
    {
        switch (m_BulletPolar)
        {
            case BulletPolar.Neutron:
                m_BulletPolar = BulletPolar.Proton;
                break;
            case BulletPolar.Proton:
                m_BulletPolar = BulletPolar.Neutron;
                break;
        }
    }

    public void AddProtonMark(GameObject mark)
    {
        m_PositiveMarks.Add(mark);
    }
    public void RemoveProtonMark(GameObject mark)
    {
        m_PositiveMarks.Remove(mark);
    }

    public void AddNeutronMark(GameObject mark)
    {
        m_NegativeMarks.Add(mark);
    }
    public void RemoveNeutronMark(GameObject mark)
    {
        m_NegativeMarks.Remove(mark);
    }

    public void SpawnChasingBullet(List<GameObject> markTypeList)
    {
        m_ParabolaRoot.m_ParabolaEnd.transform.position = markTypeList[Random.Range(0, markTypeList.Count)].transform.position;
        m_playerPool.m_ObjectPool.SpawnFromPool("CobaltBullet", m_ParabolaRoot.m_ParabolaEnd.transform.position, Quaternion.identity);
    }

    private void ChangeMiddlePoint()
    {
        /*
        _xDifference = _parabolaOrigin.transform.position.x - _parabolaEnd.transform.position.x;
        _yDifference = _parabolaOrigin.transform.position.y - _parabolaEnd.transform.position.y;

        if (_parabolaOrigin.transform.position.x > _parabolaEnd.transform.position.x && _xDifference <= 5f)
        {
            _parabolaDistanceX = _parabolaOrigin.transform.position.x + 1f;
            _parabolaDistanceY = _yDifference + 1f;
        }
        else if (_parabolaOrigin.transform.position.x > _parabolaEnd.transform.position.x && _xDifference >= 5f)
        {
            _parabolaDistanceX = _parabolaOrigin.transform.position.x + 2f;
            _parabolaDistanceY = _yDifference + 2f;
        }
        else if (_parabolaOrigin.transform.position.x < _parabolaEnd.transform.position.x && _xDifference >= -5f)
        {
            _parabolaDistanceX = _parabolaOrigin.transform.position.x - 1f;
            _parabolaDistanceY = _yDifference + 1f;
        }
        else if (_parabolaOrigin.transform.position.x < _parabolaEnd.transform.position.x && _xDifference <= -5f)
        {
            _parabolaDistanceX = _parabolaOrigin.transform.position.x - 2f;
            _parabolaDistanceY = _yDifference + 2f;
        }

        _parabolMiddlePoint.transform.position = new Vector3(_parabolaDistanceX, _parabolaDistanceY, 0f);
        */
    }
}
