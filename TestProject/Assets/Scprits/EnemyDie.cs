using System;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public EnemyCounter enemyCounter;
    
    public void Die()
    {
        enemyCounter.DieEnemy();
        
        Destroy(gameObject);
    }
}