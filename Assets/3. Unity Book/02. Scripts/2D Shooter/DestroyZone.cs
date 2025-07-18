using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet")) // 총알 오브젝트인지 확인
        {
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject); // PlayerFire 싱글톤의 풀에 추가
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject); // PlayerFire 싱글톤의 큐에 추가
            other.gameObject.SetActive(false); // 총알 비활성화
        }
        else
        {
            // EnemyManager.Instance.enemyObjectPool.Add(other.gameObject); // EnemyManager 싱글톤의 풀에 추가
            EnemyManager.Instance.enemyObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false); // 총알,Enemy 오브젝트 비활성화  
        }
    }
}
