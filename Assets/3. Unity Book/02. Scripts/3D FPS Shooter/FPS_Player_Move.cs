using UnityEngine;

public class FPS_Player_Move : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f; // ���� �Ŀ�
    public bool isJumping = false; // ���� ������ ����

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // ũ��� ���⸸ �ִ� ����
        dir = dir.normalized; // ���⸸ �ִ� ����

        // ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity; 

        cc.Move(dir * moveSpeed * Time.deltaTime); // ĳ���� ��Ʈ�ѷ��� ����� �̵����

        if (cc.collisionFlags == CollisionFlags.Below) // �ٴڿ� ����ִ��� Ȯ��
        {
            if (isJumping)
                isJumping = false;

            yVelocity = 0f; // ������ ������ yVelocity�� 0���� �ʱ�ȭ
        }

        // ���� ���
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true; // ���� ������ ����
            yVelocity = jumpPower; // ���� �Ŀ��� yVelocity�� �Ҵ�
        }
    }
}
