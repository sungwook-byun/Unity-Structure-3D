using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // �ڷ��� [ ] : ���� �迭
    public int[] array1; // �迭 ����
    public int[] array2 = { 10, 20, 30, 40, 50 }; // �迭 ����� �ʱ�ȭ
    public int[] array3 = new int[5]; // �迭 ����� ũ�� ����
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // �迭 ����� ũ�� ���� �� �ʱ�ȭ

    void Start()
    {
        int number = array2[3];
    }

}


