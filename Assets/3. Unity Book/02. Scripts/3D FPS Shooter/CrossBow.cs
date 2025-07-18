using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    // ȭ���� �߻��ϴ� ���
    // ȭ��
    // �߻��� ��ġ
    // ȭ���� ���ư��� ��� -> Arrow ��ũ��Ʈ�� �ۼ�

    public GameObject arrowPrefab; // ȭ�� ������
    public Transform shootPos; // ȭ���� �߻�� ��ġ
    public bool isShoot;


    private void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // ������ ���� ���

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootPos.position, shootPos.forward, Color.green); // ������ �ð�ȭ

        if (isTargeting && !isShoot)
            StartCoroutine(ShootRoutine()); // �������� ������ ShootRoutine �ڷ�ƾ ���� 
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0)); // ȭ���� ȸ�� ����  
        arrow.transform.SetPositionAndRotation(shootPos.position, rot); // ȭ���� �߻�� ��ġ�� ȸ�� ����

        yield return new WaitForSeconds(3f); // 3�� ���
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f); // ȭ���� �߻�� ��ġ���� ������ �ð�ȭ
    }
}
