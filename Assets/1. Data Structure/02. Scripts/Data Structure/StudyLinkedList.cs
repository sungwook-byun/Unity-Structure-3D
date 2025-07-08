using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList1 = new LinkedList<int>();
    public LinkedListNode<int> node2;

    private void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            linkedList1.AddLast(i); // 1 ~ 10���� �߰�
        }

        linkedList1.AddFirst(100); // ���� �տ��ٰ� 100�� ����
        linkedList1.AddLast(200); // ���� �ڿ��ٰ� 200�� ����

        var node = linkedList1.AddFirst(1);
        

        linkedList1.AddBefore(node, 300);
        linkedList1.AddAfter(node2, 400);
    }
}
