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

        if (currentTime > createTime) // Ÿ�̸Ӱ� ���� �ֱ⸦ �Ѿ��ٸ�
        {
            // ����
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;


            // Ÿ�̸� �ʱ�ȭ
            currentTime = 0;

        }
    }
}
