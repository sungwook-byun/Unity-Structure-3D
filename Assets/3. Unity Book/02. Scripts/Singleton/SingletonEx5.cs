using Unity.VisualScripting;
using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance;
    public static SingletonEx5 Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindAnyObjectByType<SingletonEx5>(); // 찾아보는 기능

                if (obj != null) // 찾은 경우
                { 
                    instance = obj;
                }
                else // 못 찾은 경우
                {
                    var newObj = new GameObject("Singleton");
                    newObj.AddComponent<SingletonEx5>();
                    instance = newObj.GetComponent<SingletonEx5>();
                }

            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스는 파괴
        }
    }

}
