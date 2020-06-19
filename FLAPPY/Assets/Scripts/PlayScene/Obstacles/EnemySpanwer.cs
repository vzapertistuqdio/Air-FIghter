using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    private float maxY = 4.6f;
    private float minY = -3.5f;

    [SerializeField] private GameObject enemyPrefab;

    public float minSpawnTime;
    public float maxSpawnTime;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, Random.Range(minSpawnTime,maxSpawnTime));
    }

    private void SpawnEnemy()
    {
        GameObject enemy;
        enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.position = new Vector2(transform.position.x, Random.Range(-3.5f, 4.6f));
    }
}
