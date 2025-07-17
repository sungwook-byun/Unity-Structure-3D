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
            dir = target.transform.position - transform.position; // �÷��̾ �ٶ󺸴� ���� ��
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

        // ��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if(other.gameObject.name.Contains("Bullet"))
        { 
            // PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject); // PlayerFire �̱����� Ǯ�� �߰�
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject); // PlayerFire �̱����� ť�� �߰�
            other.gameObject.SetActive(false); // �Ѿ� ��Ȱ��ȭ
        }
        else
        { 
            Destroy(other.gameObject); // �÷��̾� ������Ʈ
        }

        // EnemyManager.Instance.enemyObjectPool.Add(gameObject); // EnemyManager �̱����� Ǯ�� �߰�
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false); // Enemy ������Ʈ ��Ȱ��ȭ

    }
}