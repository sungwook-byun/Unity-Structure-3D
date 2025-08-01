using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private void Start()
    {
        MethodA();
        MethodB();
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }

}

// 변수, 함수이름이 동일하면 X
public partial class StudyPartial : MonoBehaviour
{
    private void MethodB()
    {
        Debug.Log("Method B");
    }
}




