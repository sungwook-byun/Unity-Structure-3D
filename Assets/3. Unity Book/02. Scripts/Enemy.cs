using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;

    void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7) // 70%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; // 플레이어를 바라보는 방향 값
            dir.Normalize();
        }
        else // 30%
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;

        // 파티클 생성
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if(other.gameObject.name.Contains("Bullet"))
        { 
            // PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject); // PlayerFire 싱글톤의 풀에 추가
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject); // PlayerFire 싱글톤의 큐에 추가
            other.gameObject.SetActive(false); // 총알 비활성화
        }
        else
        { 
            Destroy(other.gameObject); // 플레이어 오브젝트
        }

        // EnemyManager.Instance.enemyObjectPool.Add(gameObject); // EnemyManager 싱글톤의 풀에 추가
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false); // Enemy 오브젝트 비활성화

    }
}