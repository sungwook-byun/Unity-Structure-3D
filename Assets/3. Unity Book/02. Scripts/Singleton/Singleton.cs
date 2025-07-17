using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var t = FindFirstObjectByType<T>(); 

                if(t != null) // ã�� ���
                { 
                    instance = t;
                }
                else // �� ã�� ���
                {
                    var newObj = new GameObject(typeof(T).ToString());
                    newObj.AddComponent<T>();

                    instance = newObj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    // ������ ������ virtual
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� �ı�
        }
    }
}
