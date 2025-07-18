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
        var closetPos = other.ClosestPoint(transform.position); // �浹�� ����� ���� ����� ��ġ

        transform.position = closetPos; // ȭ���� ��ġ�� �浹�� ����� ���� ����� ��ġ�� ����.
        transform.SetParent(other.transform); // �÷��̾�� ȭ���� �θ�-�ڽ� ����� ����
        isMove = false; // �÷��̾�� �浹�ϸ� ȭ�� �̵� ����
    }
}
