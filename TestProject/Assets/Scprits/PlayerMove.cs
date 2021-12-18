using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private bool facingRight;

    private Animator _animator;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerInput.HorizontalAxisRaw < 0 && facingRight)
        {
            Flipper.FlipX(transform);
            facingRight = false;
        } else if (_playerInput.HorizontalAxisRaw > 0 && !facingRight)
        {
            Flipper.FlipX(transform);
            facingRight = true;
        }

        _rigidbody2D.velocity = new Vector2(_playerInput.HorizontalAxis * force, _rigidbody2D.velocity.y);
        _animator.SetFloat("velocityX", Mathf.Abs(_rigidbody2D.velocity.x));
    }
}
