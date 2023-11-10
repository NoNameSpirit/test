using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHealth
{
    private Animator _animator;
    private float _startingHealth;
    private string _hurtAnimationName;
    public float CurrentHealth { get; private set; }

    public CommonHealth(float startHealth, Animator animator, string hurtAnimation)
    {
        CurrentHealth = _startingHealth = startHealth;
        _animator = animator;
        _hurtAnimationName = hurtAnimation;
    }

    public DamageResult TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _startingHealth);
        if (CurrentHealth > 0)
        {
            _animator.SetTrigger(_hurtAnimationName);
            return DamageResult.Alive;
        }
        
        return DamageResult.Dead;
    }
    
    public enum DamageResult
    {
        Alive,
        Dead
    }
}

