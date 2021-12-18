using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.zero;
    public GameObject pufPrefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyDie enemyDie))
        {
            enemyDie.Die();
        }

        GameObject puf = Instantiate(pufPrefab, transform.position, Quaternion.identity);
        Destroy(puf, 2);
        
        Destroy(gameObject);
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}