using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlimeAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Animator _animator;
    //private Health health; �� ��������
    private void Awake()
    {
        //health = GetComponent<Health>();�� ��������
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Player")
        {
            _animator.SetTrigger(AnimationConstant.Slime.Attack);
            collider.GetComponent<CharacterHealth>().TakeDamage(_damage);
            //colider.health.TakeDamage(damage); // �� ��������, why? 
        }

    }
    
}
