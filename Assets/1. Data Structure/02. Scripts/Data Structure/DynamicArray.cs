using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    private void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            list1.Add(i);
        }

        list1.Insert(5, 100); // 6번째에 100을 삽입

        list1.Remove(3); // 값이 3인 첫 번째 요소를 제거

        list1.RemoveAt(5); // 인덱스 5번에 있는 값을 제거

        list1.RemoveRange(1, 3); // 인덱스 1부터 3개 요소를 제거

        list1.Clear(); // 모든 요소 제거

        list1.RemoveAll(i => i > 5 && i < 9); // 5보다 크고 9보다 작은 모든 요소 제거

        list1.Sort(); // 오름차순 정렬

        list1.Reverse(); // 내림차순 정렬

        string str = string.Empty;
        foreach(var x in list1)
        {
            str += x.ToString() + ", ";
        }

        Debug.Log(str);
    }

}
