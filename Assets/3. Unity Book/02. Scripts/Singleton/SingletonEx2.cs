using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance 
    { 
        get; // ���� ����
        private set; // ���� �Ұ�
    }

    private void Awake()
    {
        if (Instance == null) // Instance�� ��������� �ڽ�(this)�� �Ҵ�
        {
            Instance = this;
        }
        else // �̹� SingletonEx2�� �����ϸ� this ��ũ��Ʈ ���� -> �ߺ� ���� ����
        {
            Destroy(gameObject);
        }
    }
}
