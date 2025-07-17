#define DEBUG_TEXT

using System.Collections.Generic;
using UnityEngine;


public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool; // �迭
    // public List<GameObject> bulletObjectPool; // ����Ʈ
    public Queue<GameObject> bulletObjectPool; // ť

    void Start()
    {
        // bulletObjectPool = new GameObject[poolSize]; // �迭
        // bulletObjectPool = new List<GameObject>(); // ����Ʈ
        bulletObjectPool = new Queue<GameObject>(); // ť

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // bulletObjectPool[i] = bullet; // �迭
            // bulletObjectPool.Add(bullet); // ����Ʈ
            bulletObjectPool.Enqueue(bullet); // ť

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDARDALONE || UNITY_EDITOR || DEBUG_TEST
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("���콺 Ŭ��");
            // ť
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("�հ��� ��ġ");

            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#else
        Debug.Log("�� �� ������ �÷���");
#endif
    }
}