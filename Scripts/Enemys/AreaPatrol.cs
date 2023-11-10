using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class AreaPatrol : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private float _startTime;
    [SerializeField] private Transform[] _movePoints;

    private int _randomPoint;
    private float _waitTime;

    void Start()
    {
        _waitTime = _startTime;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _movePoints[_randomPoint].position, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _movePoints[_randomPoint].position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomPoint = Random.Range(0, _movePoints.Length);
                _waitTime = _startTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
