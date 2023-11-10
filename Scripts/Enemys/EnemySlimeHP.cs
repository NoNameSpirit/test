using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemySlimeHP : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Animator _animator;

    private float _timeToDie = 1.5f;
    private CommonHealth _health;
    private Collider2D _collider; 

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _health = new CommonHealth(_maxHealth, _animator, AnimationConstant.Slime.Hurt);
    }
    
    public void TakeDamage(int damage)
    {
        if (_health.TakeDamage(damage) == CommonHealth.DamageResult.Dead)
        {
            Die();
        }
    }

    public void Die()
    {
        _animator.SetBool(AnimationConstant.Slime.Death, true);
            _collider.enabled = false;
            this.enabled = false;               //��������� script(a) �����,  Enemy - disabled
            //Destroy(this, 2000);                // ���� �� �������c� ��������� -_- // ????????????
        Invoke(nameof(disaster), _timeToDie);      // �������� ������ 2 ��� � ������ ������
    }

    private void disaster()
    {
        gameObject.SetActive(false);        
    }
}




//collider.GetComponentInChildren<Collider2D>().enabled = false; - doesn't work    q_q
//GetComponent<Collider2D>().isTrigger = false; - doesn't work - _-
