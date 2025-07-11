using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2 , Lv3 };
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1;

    public GameObject[] donutPrefab;
    public BoardBar[] bars; // L, C, R

    public TextMeshProUGUI countTextUI;
    public Button answerButton;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;

    private void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

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

    public void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }

    private void HanoiRoutine(int n, int from, int temp, int to)
    {
        if(n == 1)
            Debug.Log($"{n}�� ������ {from}���� {to}�� �̵�");

        else
        {
            HanoiRoutine(n - 1, from, to, temp);
            Debug.Log($"{n}�� ������ {from}���� {to}�� �̵�");

            HanoiRoutine(n - 1, temp, from, to);
        }

    }
}
