using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public List<int> list1 = new List<int>();

    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;


    private void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            stack.Push(i); // 1 ~ 10���� ���� Stack�� �߰�
        }

        // Debug.Log(Stack[5]); // �ε��� ���x

        Debug.Log(stack.Pop()); // �� ������ �ƴ� �������� ���� ������ �̾ƿ�. ������ ���� �̾ƿ�.
        Debug.Log(stack.Count);

        Debug.Log(stack.Peek()); // �� ������ ���� ����� Ȯ��
        Debug.Log(stack.Count);

        Debug.Log(stack.Pop()); 
        Debug.Log(stack.Count);
        //
        //
        stack = new Stack<int>(array);
        list1 = stack.ToList();
        array2 = stack.ToArray();
    }
}
