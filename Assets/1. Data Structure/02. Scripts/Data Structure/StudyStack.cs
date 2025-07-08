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
            stack.Push(i); // 1 ~ 10까지 값을 Stack에 추가
        }

        // Debug.Log(Stack[5]); // 인덱서 기능x

        Debug.Log(stack.Pop()); // 들어간 순서가 아닌 마지막에 넣은 값부터 뽑아옴. 마지막 값만 뽑아옴.
        Debug.Log(stack.Count);

        Debug.Log(stack.Peek()); // 그 다음에 뽑힐 대상을 확인
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
