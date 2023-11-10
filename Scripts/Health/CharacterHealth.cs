using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _startingHealth;

    private Animator _animator;
    private bool _dead;
    private Vector3 _startPosition;
    private CommonHealth _health;
    private PlayerMovement _playerController;

    public float CurrentHealth => _health.CurrentHealth; //  => у типа float как это работает? зачем => почему допустим = не работает.( из-за того, что является свойством?)  

    private void Awake()
    {
        _playerController = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _health = CreateCommonHealth();
    }

    public void TakeDamage(float damage)
    {
        if (_health.TakeDamage(damage) != CommonHealth.DamageResult.Dead)
        {
            return;
        }

        if (!_dead)
        {
            _animator.SetTrigger(AnimationConstant.Character.Die);
            _playerController.enabled = false; 
            _dead = true;
            Invoke(nameof(Reset), 1);
        }
    }

    private void Reset()
    {
        transform.position = _startPosition;
        _playerController.enabled = true;
        _dead = false;
        _animator.SetTrigger(AnimationConstant.Character.Alive);
        _health = CreateCommonHealth();
    }

    private CommonHealth CreateCommonHealth()
    {
        return new CommonHealth(_startingHealth, _animator, AnimationConstant.Character.Hurt);
    }
}

