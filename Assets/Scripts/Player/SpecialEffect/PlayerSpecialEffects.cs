using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialEffects //: MonoBehaviour
{
    /*
    public RippleEffect _rippleEffect;
    public Color _color;
    public EchoScript[] _echoScript;

    [SerializeField] private GameObject _preAirDashSparkPlus;
    [SerializeField] private GameObject _preAirDashSparkMin;
    [SerializeField] private GameObject _preAirDashSparkOutline;

    [SerializeField] private GameObject _airDashSparkPlus;
    [SerializeField] private GameObject _airDashSparkMin;
    [SerializeField] private GameObject _airDashSparkOutline;

    [SerializeField] private GameObject _airDiveSparkPlus;
    [SerializeField] private GameObject _airDiveSparkMin;
    [SerializeField] private GameObject _airDiveSparkOutline;

    [SerializeField] private GameObject _shootingEffectPlus;
    [SerializeField] private GameObject _shootingEffectMin;

    private CobaltBehaviour _cobaltBehaviour;
    private bool _preAirDashSparkActivated;
    private bool _airDashSparkActivated;
    private bool _airDiveSparkActivated;
    

    private void Awake()
    {
        _cobaltBehaviour = FindObjectOfType<CobaltBehaviour>();
        _rippleEffect = FindObjectOfType<RippleEffect>();
    }

    private void Update()
    {
        switch (_cobaltBehaviour._bulletState)
        {
            case CobaltBulletState.negative:
                _color = new Color(0, 0.98f, 1f);
                if (_preAirDashSparkActivated)
                {
                    _preAirDashSparkMin.SetActive(true);
                    _preAirDashSparkPlus.SetActive(false);
                    _preAirDashSparkOutline.SetActive(true);
                }
                else
                {
                    _preAirDashSparkMin.SetActive(false);
                    _preAirDashSparkPlus.SetActive(false);
                    _preAirDashSparkOutline.SetActive(false);
                }

                if (_airDashSparkActivated)
                {
                    _airDashSparkMin.SetActive(true);
                    _airDashSparkPlus.SetActive(false);
                    _airDashSparkOutline.SetActive(true);
                }
                else
                {
                    _airDashSparkMin.SetActive(false);
                    _airDashSparkPlus.SetActive(false);
                    _airDashSparkOutline.SetActive(false);
                }

                if (_airDiveSparkActivated)
                {
                    _airDiveSparkMin.SetActive(true);
                    _airDiveSparkPlus.SetActive(false);
                    _airDiveSparkOutline.SetActive(true);
                }
                else
                {
                    _airDiveSparkMin.SetActive(false);
                    _airDiveSparkPlus.SetActive(false);
                    _airDiveSparkOutline.SetActive(false);
                }
                break;
            case CobaltBulletState.positive:
                _color = new Color(1f, 0.45f, 0.4f);
                if (_preAirDashSparkActivated)
                {
                    _preAirDashSparkPlus.SetActive(true);
                    _preAirDashSparkMin.SetActive(false);
                    _preAirDashSparkOutline.SetActive(true);
                }
                else
                {
                    _preAirDashSparkPlus.SetActive(false);
                    _preAirDashSparkMin.SetActive(false);
                    _preAirDashSparkOutline.SetActive(false);
                }

                if (_airDashSparkActivated)
                {
                    _airDashSparkPlus.SetActive(true);
                    _airDashSparkMin.SetActive(false);
                    _airDashSparkOutline.SetActive(true);
                }
                else
                {
                    _airDashSparkPlus.SetActive(false);
                    _airDashSparkMin.SetActive(false);
                    _airDashSparkOutline.SetActive(false);
                }

                if (_airDiveSparkActivated)
                {
                    _airDiveSparkPlus.SetActive(true);
                    _airDiveSparkMin.SetActive(false);
                    _airDiveSparkOutline.SetActive(true);
                }
                else
                {
                    _airDiveSparkPlus.SetActive(false);
                    _airDiveSparkMin.SetActive(false);
                    _airDiveSparkOutline.SetActive(false);
                }
                break;
        }
        _shootingEffectPlus.transform.position = _cobaltBehaviour._gunOrigin;
        _shootingEffectMin.transform.position = _cobaltBehaviour._gunOrigin;
    }

    public void DeactiveAllEffects()
    {
        _preAirDashSparkActivated = false;
        _preAirDashSparkPlus.SetActive(false);
        _preAirDashSparkMin.SetActive(false);
        _preAirDashSparkOutline.SetActive(false);
        _airDashSparkActivated = false;
        _airDashSparkPlus.SetActive(false);
        _airDashSparkMin.SetActive(false);
        _airDashSparkOutline.SetActive(false);
        _shootingEffectPlus.SetActive(false);
        _shootingEffectMin.SetActive(false);
        _airDiveSparkActivated = false;
        _airDiveSparkPlus.SetActive(false);
        _airDiveSparkMin.SetActive(false);
        _airDiveSparkOutline.SetActive(false);
    }

    public void SpawnShotEffect()
    {
        switch (_cobaltBehaviour._bulletState)
        {
            case CobaltBulletState.negative:
                _shootingEffectPlus.SetActive(false);
                _shootingEffectMin.SetActive(false);
                _shootingEffectMin.SetActive(true);
                break;
            case CobaltBulletState.positive:
                _shootingEffectMin.SetActive(false);
                _shootingEffectPlus.SetActive(false);
                _shootingEffectPlus.SetActive(true);
                break;
        }
    }

    public void DeactivePreAirdashSparks()
    {
        _preAirDashSparkActivated = false;
    }
    public void ActivePreAirdashSparks()
    {
        _preAirDashSparkActivated = true;
    }

    public void DeactiveAirdashSparks()
    {
        _airDashSparkActivated = false;
    }
    public void ActiveAirdashSparks()
    {
        _airDashSparkActivated = true;
    }

    public void DeactiveAirDiveSparks()
    {
        _airDiveSparkActivated = false;
    }
    public void ActiveAirDiveSparks()
    {
        _airDiveSparkActivated = true;
    }

    public void EmitRipple(Vector3 position)
    {
        _rippleEffect.Emit(Camera.main.WorldToViewportPoint(position));
    }

    public void SpawnEcho()
    {
        if (_echoScript != null)
        {
            for (int i = 0; i < _echoScript.Length; i++)
            {
                _echoScript[i].gameObject.SetActive(true);
                _echoScript[i]._color = _color;
            }
        }
    }
    public void DespawnEcho()
    {
        if (_echoScript != null)
        {
            for (int i = 0; i < _echoScript.Length; i++)
            {
                _echoScript[i].gameObject.SetActive(false);
            }
        }
    }
    */
}
