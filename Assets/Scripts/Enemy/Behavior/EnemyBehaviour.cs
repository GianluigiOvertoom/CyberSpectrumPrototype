using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void OnEnter();
    void HandleBehaviour();
    void HandlePhysics();
    void OnExit();
}

public class EnemyBehaviour : MonoBehaviour
{
    private IEnemyState m_EnemyState;

    private void Start()
    {
        
    }

    private void Update()
    {
        m_EnemyState.HandleBehaviour();
    }

    private void FixedUpdate()
    {
        m_EnemyState.HandlePhysics();
    }

    public void SwitchState(IEnemyState newEnemyState)
    {
        if (newEnemyState.Equals(null))
            return;
        m_EnemyState.OnExit();
        m_EnemyState = newEnemyState;
        m_EnemyState.OnEnter();
    }
}
