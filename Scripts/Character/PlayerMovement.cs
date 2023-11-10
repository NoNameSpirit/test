using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float Speed;

    private Vector2 _direction;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {   
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        
        if (inputHorizontal < 0) //player rotate <-  or  ->
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (inputHorizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        var isHorizontalAndVertical = inputHorizontal != 0 && inputVertical != 0;
        if (!isHorizontalAndVertical)
        {
            _animator.SetBool(AnimationConstant.Character.RunVerticalUp, inputVertical > 0);
            _animator.SetBool(AnimationConstant.Character.RunVerticalDown, inputVertical < 0);
            _animator.SetBool(AnimationConstant.Character.Run, inputHorizontal != 0);
        }

        _direction.x = inputHorizontal;
        _direction.y = inputVertical;
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _direction * Speed * Time.fixedDeltaTime);
    }

}
