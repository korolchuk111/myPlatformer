using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemyCounter : MonoBehaviour
{
    private float coolDown = 3;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private int _enemyCount;
    [SerializeField] private GameObject _enemyPrefab;

    private Random _random;
    public void Start()
    {
        _enemyCount = transform.childCount;
        _random = new Random();
    }

    public void Update()
    {
        coolDown += -Time.deltaTime;

        if (coolDown < 0)
        {
            coolDown = 3;
            SpawnEnemy();
        }

        if (_enemyCount <= 0)
        {
            YouWin();
        }
    }

    public void DieEnemy()
    {
        _enemyCount += -1;
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += _random.Next(-5, 5);

        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyDie enemyDie =  enemy.GetComponent<EnemyDie>();
        enemyDie.enemyCounter = this;
        _enemyCount += 1;
    }

    private void YouWin()
    {
        _winPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}