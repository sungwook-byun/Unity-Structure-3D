using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet")) // �Ѿ� ������Ʈ���� Ȯ��
        {
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject); // PlayerFire �̱����� Ǯ�� �߰�
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject); // PlayerFire �̱����� ť�� �߰�
            other.gameObject.SetActive(false); // �Ѿ� ��Ȱ��ȭ
        }
        else
        {
            // EnemyManager.Instance.enemyObjectPool.Add(other.gameObject); // EnemyManager �̱����� Ǯ�� �߰�
            EnemyManager.Instance.enemyObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false); // �Ѿ�,Enemy ������Ʈ ��Ȱ��ȭ  
        }
    }
}
