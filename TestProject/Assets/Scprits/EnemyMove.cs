using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool facingRight;
    [SerializeField] private Transform from;
    [SerializeField] private ContactFilter2D contactFilter2D;

    private bool _canMoveNext;
    private Vector3 _direction;
    
    private List<RaycastHit2D> _rayDownResults;
    private List<RaycastHit2D> _rayHorizontalResults;
    
    private void Start()
    {
        _rayDownResults = new List<RaycastHit2D>();
        _rayHorizontalResults = new List<RaycastHit2D>();

        if (facingRight)
        {
            _direction = Vector3.right;
        }
        else
        {
            _direction = Vector3.left;
            Flipper.FlipX(transform);
        }
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        var rayDownResultCount = Physics2D.Raycast(@from.position, Vector3.down, 
            contactFilter2D, _rayDownResults, 0.2f);
        
        var rayHorizontalResultCount = Physics2D.Raycast(transform.position, _direction, 
            contactFilter2D, _rayHorizontalResults, 0.8f);

        _canMoveNext = rayDownResultCount != 0 && rayHorizontalResultCount == 0;
        
        if (!_canMoveNext)
        {
            _direction = -_direction;
            Flipper.FlipX(transform);
        }
    }
}
