using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumpCount;
    [SerializeField] private Transform from;
    [SerializeField] private ContactFilter2D contactFilter2D;

    private List<RaycastHit2D> _results;
    private Animator _animator;
    private int _jumpCount;
    private bool _canJump = true;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _results = new List<RaycastHit2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        if(!_canJump) return;
        
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        _jumpCount++;
    }

    private void Update()
    {
        if (_jumpCount == maxJumpCount)
        {
            _canJump = false;
            _jumpCount = 0;
        }
        
        _animator.SetFloat("velocityY", Mathf.Abs(_rigidbody2D.velocity.y));
        
        if(Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
        var resultCount = Physics2D.Raycast(@from.position, Vector2.down, contactFilter2D, _results, 0.2f);

        if (resultCount != 0)
        {
            _canJump = true;
        }
    }
}
