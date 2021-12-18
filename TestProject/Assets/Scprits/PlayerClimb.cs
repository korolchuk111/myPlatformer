using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private float climbForce;

    private bool _isLadder;
    private float _startGravity;
    private bool _isClimb;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    [SerializeField] private Grid grid;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startGravity = _rigidbody2D.gravityScale;
    }

    private void Update()
    {
        _isClimb = _isLadder && Mathf.Abs(_playerInput.VerticlAxis) > 0;
        
        _animator.SetBool("isClimb", _isClimb);
    }

    private void FixedUpdate()
    {
        if (_isClimb)
        {
            _rigidbody2D.gravityScale = 0;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, climbForce * _playerInput.VerticlAxis);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ladder ladder))
        {
            _isLadder = true;
            _animator.SetBool("isOnLadder", true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ladder ladder))
        {
            _isLadder = false;
            _animator.SetBool("isOnLadder", false);
            _rigidbody2D.gravityScale = _startGravity;
        }
    }
}
