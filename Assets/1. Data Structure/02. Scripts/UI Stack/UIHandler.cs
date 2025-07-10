using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    // RectTransform = UI���� transform��.
    private RectTransform parentRect;

    private Vector2 basePos;
    private Vector2 startPos;
    private Vector2 moveOffset;

    void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); // ���� �׷������� ����

        basePos = parentRect.anchoredPosition; // ���� UI�� ��ġ
        startPos = eventData.position; // ������
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; // �巡���� ������ Dir
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
