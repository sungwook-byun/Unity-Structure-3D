using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;

    private float minTime = 1f;
    private float maxTime = 5f;

    public float createTime = 1f;

    public GameObject enemyFactory;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // 타이머가 생성 주기를 넘었다면
        {
            // 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;


            // 타이머 초기화
            currentTime = 0;

        }
    }
}
