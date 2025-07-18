using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    // public GameObject[] enemyObjectPool; // �迭
    // public List<GameObject> enemyObjectPool; // ����Ʈ
    public Queue<GameObject> enemyObjectPool; // ť

    public Transform[] spawnPoints;

    public GameObject enemyFactory;

    private float currentTime; // Ÿ�̸�
    private float minTime = 1;
    private float maxTime = 5;
    public float createTime = 1f; // ���� �ֱ�

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        // enemyObjectPool =  new GameObject[poolSize]; // �迭
        // enemyObjectPool = new List<GameObject>(); // ����Ʈ
        enemyObjectPool = new Queue<GameObject>(); // ť

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            // enemyObjectPool[i] = enemy; // �迭
            // enemyObjectPool.Add(enemy); // ����Ʈ
            enemyObjectPool.Enqueue(enemy); // ť

            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // ������ �ð��� �� �� ���� ������ ��ġ�� Enemy ����
        {
            // ť
            if (enemyObjectPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool.Dequeue();

                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);
            }
        }
    }
}