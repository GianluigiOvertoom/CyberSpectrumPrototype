using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffect //: MonoBehaviour
{
    /*
    private PlayerBehaviour _playerBehaviour;
    private SpriteRenderer _spriteRenderer;
    private PlayerSpecialEffects _playerSpecialEffects;
    private ObjectPooler _objectPooler;
    private CobaltBehaviour _cobaltBehaviour;
    private Quaternion _circlequaternion;

    private void Start()
    {
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerSpecialEffects = FindObjectOfType<PlayerSpecialEffects>();
        _objectPooler = ObjectPooler.Instance;
        _cobaltBehaviour = FindObjectOfType<CobaltBehaviour>();        
    }

    private void Update()
    {
        _spriteRenderer.flipX = _playerBehaviour._spriteRenderer.flipX;
    }

    private void OnBecameVisible()
    {
        _spriteRenderer.flipX = _playerBehaviour._spriteRenderer.flipX;
    }

    public void SetInactive()
    {
        this.gameObject.SetActive(false);
    }

    public void SpawnDashRingEffect()
    {
        GameObject backRing;
        GameObject frontRing;
        backRing = _objectPooler.SpawnFromPool("FrontRing", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + (1f * _playerBehaviour._direction), _playerBehaviour._rigidbody2D.transform.position.y), Quaternion.identity);
        backRing.GetComponent<SpriteRenderer>().color = _playerSpecialEffects._color;
        frontRing = _objectPooler.SpawnFromPool("BackRing", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + (1f * _playerBehaviour._direction), _playerBehaviour._rigidbody2D.transform.position.y), Quaternion.identity);
        frontRing.GetComponent<SpriteRenderer>().color = _playerSpecialEffects._color;
    }

    public void SpawnDiveRingEffect()
    {
        switch (_playerBehaviour._direction)
        {
            case 1:
                _circlequaternion = new Quaternion(1f, -0.5f, 0f, 0f);
                break;
            case -1:
                _circlequaternion = new Quaternion(0f, 0f, 1f, -0.5f);
                break;
        }
        GameObject backRing;
        GameObject frontRing;
        backRing = _objectPooler.SpawnFromPool("FrontRing", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + (1f * _playerBehaviour._direction), _playerBehaviour._rigidbody2D.transform.position.y - 2f) , _circlequaternion);
        backRing.GetComponent<SpriteRenderer>().color = _playerSpecialEffects._color;
        frontRing = _objectPooler.SpawnFromPool("BackRing", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + (1f * _playerBehaviour._direction), _playerBehaviour._rigidbody2D.transform.position.y - 2f), _circlequaternion);
        frontRing.GetComponent<SpriteRenderer>().color = _playerSpecialEffects._color;
    }

    public void SpawnDashEffect()
    {
        switch (_cobaltBehaviour._bulletState)
        {
            case CobaltBulletState.negative:
                _objectPooler.SpawnFromPool("DashEffectMin", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -1f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y + 0.16f), Quaternion.identity);
                break;
            case CobaltBulletState.positive:
                _objectPooler.SpawnFromPool("DashEffectPlus", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -1f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y + 0.16f), Quaternion.identity);
                break;
        }
    }

    public void SpawnWalkEffectRight()
    {
        switch (_cobaltBehaviour._bulletState)
        {
            case CobaltBulletState.negative:
                _objectPooler.SpawnFromPool("WalkEffectMin", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -1f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y + 0.16f), Quaternion.identity);
                break;
            case CobaltBulletState.positive:
                _objectPooler.SpawnFromPool("WalkEffectPlus", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -0.81f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y + 0.16f), Quaternion.identity);
                break;
        }   
    }

    public void SpawnWalkEffectLeft()
    {
        switch (_cobaltBehaviour._bulletState)
        {
            case CobaltBulletState.negative:
                _objectPooler.SpawnFromPool("WalkEffectMin", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -1f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y), Quaternion.identity);
                break;
            case CobaltBulletState.positive:
                _objectPooler.SpawnFromPool("WalkEffectPlus", new Vector2(_playerBehaviour._rigidbody2D.transform.position.x + -0.81f * _playerBehaviour._direction, _playerBehaviour._rigidbody2D.transform.position.y), Quaternion.identity);
                break;
        }
    }

    public void EmitRipple()
    {
        //_playerSpecialEffects.EmitRipple(_playerBehaviour._rigidbody2D.transform.position);
    }
    */
}
