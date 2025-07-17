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

                if(t != null) // 찾은 경우
                { 
                    instance = t;
                }
                else // 못 찾은 경우
                {
                    var newObj = new GameObject(typeof(T).ToString());
                    newObj.AddComponent<T>();

                    instance = newObj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    // 선택적 재정의 virtual
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스는 파괴
        }
    }
}
