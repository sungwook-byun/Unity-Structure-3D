using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private GameObject bulletFactory;
    public GameObject firePosition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet"); // ���ҽ� �������� �Ѿ� ������ �ε�
    }

    private void Update()
    {
    if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; // ��ġ �ʱ�ȭ
            // bullet.transform.rotation = firePosition.transform.rotation; // ȸ�� �ʱ�ȭ

            // bullet.transform.SetPositionAndRotation(��ġ, ȸ��); // ��ġ�� ȸ���� �ѹ��� �����ϴ� ���
            // bullet.transform.SetParent(�θ�); // �θ� ������Ʈ ����
        }
        
    }
}
