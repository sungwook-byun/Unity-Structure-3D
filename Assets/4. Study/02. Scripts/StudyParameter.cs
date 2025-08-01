using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;
    public int number3;

    public int hp = 100;
    public int mp = 50;
    public int[] intArray = new int[3] { 1, 2, 3 };

    void Start()
    {
        NomalParameter(number);

        ReferenceParameter(ref number);

        OutParameter(out number2, out number3);

        UseSkill(out hp, out mp);

        ArrayParameter(intArray);
        ParamsParameter(10, 20, 30);

    }

    // 일반적인 매개변수 -> Call by Value
    private void NomalParameter(int num)
    {
        num = 10;
    }

    // 참조 방식의 매개변수 -> Call by Reference
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    private void OutParameter(out int num, out int num2)
    {
        num = 30; // 반드시 값을 할당해야 함
        num2 = 40; // 반드시 값을 할당해야 함
    }

    private void UseSkill(out int hp, out int mp)
    {
        hp = 90; 
        mp = 40;  
    }

    private void ArrayParameter(int[] numbers)
    {
        foreach(var n in numbers)
        {
            Debug.Log(n);
        }
    }

    private void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    #region 또다른 매개변수

    // 오버로딩 : 매개변수를 다르게해서 다른 기능을 구현하는 방법
    private void OverloadingMethod() { Debug.Log("기능 A"); }

    private void OverloadingMethod(int num) { Debug.Log("기능 B"); }

    private void OverloadingMethod(float num) { Debug.Log("기능 C"); }

    private void OverloadingMethod(bool isNum) { Debug.Log("기능 D"); }

    private void OverloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }
    #endregion
}