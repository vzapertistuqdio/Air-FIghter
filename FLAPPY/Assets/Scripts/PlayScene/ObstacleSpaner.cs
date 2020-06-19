using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpaner : MonoBehaviour
{
    private float maxY = 4.6f;
    private float minY = -3.5f;

    [SerializeField] private GameObject[] rocketObstacle;

    public float spawnRate;

    [SerializeField] private GameObject[] enemySpawners;

    private void Start()
    {
        StartCoroutine(EnableEnemySpawners());
        InvokeRepeating("SpawnObstacle",1,spawnRate);
    }


    private void SpawnObstacle()
    {
        GameObject obstacle;
        obstacle = Instantiate(rocketObstacle[Random.Range(0,rocketObstacle.Length)]) as GameObject;
        obstacle.transform.position = new Vector2(transform.position.x,Random.Range(-3.5f, 4.6f));
    }

    private IEnumerator EnableEnemySpawners()
    {
        yield return new WaitForSeconds(1);
        enemySpawners[0].SetActive(true);
        yield return new WaitForSeconds(5);
        enemySpawners[1].SetActive(true);
        yield return new WaitForSeconds(10);
        enemySpawners[2].SetActive(true);
        yield return new WaitForSeconds(15);
        enemySpawners[3].SetActive(true);
        yield return new WaitForSeconds(20);
        enemySpawners[4].SetActive(true);
    }
}
