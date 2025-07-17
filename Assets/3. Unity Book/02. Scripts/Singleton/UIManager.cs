using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    protected override void Awake()
    {
        base.Awake(); // 부모 클래스의 Awake 호출
        // 추가적인 초기화 작업이 필요하다면 여기에 작성
    }
}
