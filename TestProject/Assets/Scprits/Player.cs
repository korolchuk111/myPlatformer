using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;
    public UnityAction<float> damaged { get; set; }
    [SerializeField] private UnityEvent<float> scoreChanged;
    [SerializeField] private UnityEvent playerDie;

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AnimatorController view1;
    [SerializeField] private AnimatorController view2;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform _bulletStartPosition;
    
    private float _startHealth;
    private float _damageTaken;
    private float _score;

    private void Start()
    {
        _startHealth = health;
        _damageTaken = 0;

        SetPlayerView();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CreateBullet();
        }
    }

    public void ApplyScore(float score)
    {
        _score += score;
        scoreChanged?.Invoke(_score);
    }

    public void ApplyDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
        _damageTaken += damage;
        
        damaged.Invoke(1 - (_damageTaken / _startHealth));
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void CreateBullet()
    {
        float scale = transform.localScale.x;
        
        Bullet bullet = Instantiate(bulletPrefab);
        
        bullet.direction = GetDirection(scale);
        bullet.transform.position = _bulletStartPosition.position;
    }

    private void SetPlayerView()
    {
        if (PlayerPrefs.GetInt("PlayerView") == 1)
        {
            playerAnimator.enabled = false;
            playerAnimator.runtimeAnimatorController = view1;
            playerAnimator.enabled = true;
        }

        if (PlayerPrefs.GetInt("PlayerView") == 2)
        {
            playerAnimator.enabled = false;
            playerAnimator.runtimeAnimatorController = view2;
            playerAnimator.enabled = true;
        }
        else
        {
            playerAnimator.runtimeAnimatorController = view1;
        }
    }

    private static Vector3 GetDirection(float scale)
    {
        Vector3 direction;
        if (scale == -1)
            direction = Vector3.left;
        else
            direction = Vector3.right;
        return direction;
    }

    private void Die()
    {
        playerDie.Invoke();
        Destroy(gameObject);
    }
}
