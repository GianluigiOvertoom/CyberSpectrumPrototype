using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScript //: MonoBehaviour
{
    /*
    private SpriteRenderer _echoRenderer;
    public bool _canSpawn;
    public float _startSpawnTimer;
    public Color _color;
    public float _alpha;
    private float _spawnTimer;

    private void Start()
    {
        _echoRenderer = GetComponent<SpriteRenderer>();
        _spawnTimer = _startSpawnTimer;
    }

    private void OnEnable()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        if (_canSpawn)
        {
            SpawnEcho(GameObject.FindGameObjectWithTag("Player"));
        }
        if (_spawnTimer > 0)
        {
            _spawnTimer -= Time.deltaTime;
        }
        else
        {
            _canSpawn = true;
            _spawnTimer = _startSpawnTimer;
        }
    }

    public void SpawnEcho(GameObject origin)
    {
        _echoRenderer.color = new Vector4(_color.r, _color.g, _color.b, _alpha);
        _echoRenderer.sprite = origin.GetComponentInChildren<SpriteRenderer>().sprite;
        _echoRenderer.flipX = origin.GetComponentInChildren<SpriteRenderer>().flipX;
        transform.rotation = origin.transform.rotation;
        transform.position = origin.transform.position;
        _canSpawn = false;
    }
    */
}
