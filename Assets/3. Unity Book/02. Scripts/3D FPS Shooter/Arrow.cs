using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isMove = true;

    private void Update()
    {
        if (isMove) 
            transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var closetPos = other.ClosestPoint(transform.position); // 충돌한 대상의 가장 가까운 위치

        transform.position = closetPos; // 화살의 위치를 충돌한 대상의 가장 가까운 위치로 설정.
        transform.SetParent(other.transform); // 플레이어와 화살을 부모-자식 관계로 설정
        isMove = false; // 플레이어와 충돌하면 화살 이동 중지
    }
}
