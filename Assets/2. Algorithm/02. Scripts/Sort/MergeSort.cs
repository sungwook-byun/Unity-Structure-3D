using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log("���� ��: " + string.Join(", ", array));

        MSort(array, 0, array.Length - 1);
        Debug.Log("���� ��: " + string.Join(", ", array));
    }

    void MSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MSort(arr, left, mid);
            MSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // ���� �迭 ũ��
        int n2 = right - mid; // ������ �迭 ũ��

        int[] lArr = new int[n1]; // �ӽ� �迭 ũ�� ����
        int[] rArr = new int[n2]; // �ӽ� �迭 ũ�� ����

        for (int i = 0; i < n1; i++) // ���� �迭 �� �ʱ�ȭ
            lArr[i] = arr[left + i];

        for (int i = 0; i < n2; i++) // ������ �迭 �� �ʱ�ȭ
            rArr[i] = arr[mid + 1 + i];

        int j = left;
        int u = 0;
        int v = 0;

        while (u < n1 && v < n2)
        {
            if (lArr[u] <= rArr[v])
            {
                arr[j] = lArr[u];
                u++;
            }
            else
            {
                arr[j] = rArr[v];
                v++;
            }

            j++;
        }

        while (u < n1)
        {
            arr[j] = lArr[u];
            u++;
            j++;
        }

        while (v < n2)
        {
            arr[j] = rArr[v];
            j++;
            v++;
        }
    }
}