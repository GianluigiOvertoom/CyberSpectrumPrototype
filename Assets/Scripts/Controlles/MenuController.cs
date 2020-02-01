using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private InputControlles m_InputControlles;

    [SerializeField] private GameObject m_PauseMenu;

    private void Awake()
    {
        m_InputControlles = gameObject.AddComponent<InputControlles>();
        m_PauseMenu = GetComponentInChildren<Canvas>().gameObject;
    }

    private void Start()
    {
        m_PauseMenu.SetActive(false);
    }
}
