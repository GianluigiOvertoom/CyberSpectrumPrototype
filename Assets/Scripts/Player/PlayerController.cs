using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public PlayerData m_PlayerData { get; set; }
    public InputControlles m_InputControlles { get; set; }
    public CreatePool m_PlayerPool { get; set; }
    public CinemachineVirtualCamera m_PlayerCam { get; set; }

    public GameObject m_Player;
    public Vector3 m_SpawnPosition;
    public GroundType m_ColliderCheck;

    private void Awake()
    {
        m_PlayerData = ScriptableObject.CreateInstance<PlayerData>();
        m_InputControlles = gameObject.AddComponent<InputControlles>();
        m_PlayerCam = GetComponentInChildren<CinemachineVirtualCamera>();        
        m_Player = Instantiate(m_Player, m_SpawnPosition, Quaternion.identity);
        m_PlayerCam.m_Follow = m_Player.transform;
    }

    private void Start()
    {
        m_PlayerPool = GetComponent<CreatePool>();
    }

    private void Update()
    {
    }
}
