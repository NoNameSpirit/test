using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(AreaPatrol))]
[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(LayerMask))]
public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _playerLayers;
    [SerializeField] private Transform _enemyPosition; //надо ли указывать public если поле serialized или private можно
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    private Transform _target;
    private AreaPatrol _speedPatrol; // Animator an;

    void Start()
    {
        _target = _player.GetComponent<Transform>();
        _speedPatrol = GetComponent<AreaPatrol>(); //   an = GetComponent<Animator
    }

    private void Update()
    {
        CheckPlayer();    //Vector3 euler = transform.eulerAngles;
    }

    void CheckPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_enemyPosition.position, _range, _playerLayers);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, (_speed + _speedPatrol._speed) * Time.deltaTime);
            //transform.right = target.transform.position - transform.position;             // Turn to Player xDDDD
        }
    }
  }

/*
  private void OnDrawGizmosSelected()                   // View of SphereRange
    {
        if (EnemyPosition == null) return;

        Gizmos.DrawSphere(EnemyPosition.position, Range);
    }
 */