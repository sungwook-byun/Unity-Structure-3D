using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2 , Lv3 };
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefab;
    public BoardBar[] bars; // L, C, R

    public static GameObject selectedDonut;
    public static bool isSelected;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--) // �ݺ������� Level��ŭ ���� ����
        {
            GameObject donut = Instantiate(donutPrefab[i]); // ���� ����
            donut.transform.position = new Vector3(-5f, 5f, 0); // ���� ������ġ : ���ʸ������

            bars[0].PushDonut(donut); // ��� ������ ������ �ش� Bar�� Stack Push

            yield return new WaitForSeconds(1f);
        }
    }
}
