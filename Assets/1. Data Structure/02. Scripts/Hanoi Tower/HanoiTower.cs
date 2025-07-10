using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2 , Lv3 };
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefab;
    public BoardBar[] bars; // L, C, R

    public TextMeshProUGUI countTextUI;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--) // �ݺ������� Level��ŭ ���� ����
        {
            GameObject donut = Instantiate(donutPrefab[i]); // ���� ����
            donut.transform.position = new Vector3(-5f, 5f, 0); // ���� ������ġ : ���ʸ������

            bars[0].PushDonut(donut); // ��� ������ ������ �ش� Bar�� Stack Push

            yield return new WaitForSeconds(1f);
        }
        moveCount = 0;
        countTextUI.text = moveCount.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);

            isSelected = false;
            selectedDonut = null;
        }
        countTextUI.text = moveCount.ToString();
    }
}
