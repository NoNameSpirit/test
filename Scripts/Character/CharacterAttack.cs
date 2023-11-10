using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _attackRange;

    [SerializeField] private int _characterDamage;
    [SerializeField] private Transform _HorizontalAttackPoint;
    [SerializeField] private Transform _attackPointDown;
    [SerializeField] private Transform _attackPointUp;
    [SerializeField] private LayerMask _enemyLayers;

    private float _cooldownTimer = Mathf.Infinity;
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private bool _isVerticalUp;
    private bool _isVerticalDown;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float inputVertical = Input.GetAxisRaw("Vertical");
        _isVerticalUp = inputVertical > 0;
        _isVerticalDown = inputVertical < 0;
        CheckClick();

        _cooldownTimer += Time.deltaTime;
    }
    private void CheckClick()
    {
        if (Input.GetMouseButton(0) && _cooldownTimer > _attackCooldown)         // 0 - left // 1 - right // 2 - middle
            ChooseAttack();
    }
    private void ChooseAttack()
    {
        if (_isVerticalUp)
        {
            VerticalUpAttack();
        }
        else if (_isVerticalDown)
        {
            VerticalDownAttack();
        }
        else
        {
            HorizontalAttack();
        }
    }

    private void VerticalDownAttack()
    {
        _animator.SetTrigger(AnimationConstant.Character.AttackVerticalDown);
        _cooldownTimer = 0;
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPointDown.position, _attackRange, _enemyLayers);

        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<EnemySlimeHP>().TakeDamage(_characterDamage);
        }
        _isVerticalDown = false;
    }
    private void VerticalUpAttack()
    {
        _animator.SetTrigger(AnimationConstant.Character.AttackVerticalUp);
        _cooldownTimer = 0;
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPointUp.position, _attackRange, _enemyLayers);

        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<EnemySlimeHP>().TakeDamage(_characterDamage);
        }
        _isVerticalUp = false;
    }
    private void HorizontalAttack()
    {
        _animator.SetTrigger(AnimationConstant.Character.Attack);
        _cooldownTimer = 0;

        Collider2D [] hitEnemys = Physics2D.OverlapCircleAll(_HorizontalAttackPoint.position, _attackRange, _enemyLayers);
        
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<EnemySlimeHP>().TakeDamage(_characterDamage);
        }
    }
   /* private void OnDrawGizmosSelected()
    {
        if (AttackPointUp == null) return;

        Gizmos.DrawSphere(AttackPointUp.position, AttackRange);
    }*/



}
