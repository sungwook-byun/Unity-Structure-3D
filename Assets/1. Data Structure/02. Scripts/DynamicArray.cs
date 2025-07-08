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

        list1.Insert(5, 100); // 6��°�� 100�� ����

        list1.Remove(3); // ���� 3�� ù ��° ��Ҹ� ����

        list1.RemoveAt(5); // �ε��� 5���� �ִ� ���� ����

        list1.RemoveRange(1, 3); // �ε��� 1���� 3�� ��Ҹ� ����

        list1.Clear(); // ��� ��� ����

        list1.RemoveAll(i => i > 5 && i < 9); // 5���� ũ�� 9���� ���� ��� ��� ����

        list1.Sort(); // �������� ����

        list1.Reverse(); // �������� ����

        string str = string.Empty;
        foreach(var x in list1)
        {
            str += x.ToString() + ", ";
        }

        Debug.Log(str);
    }

}
