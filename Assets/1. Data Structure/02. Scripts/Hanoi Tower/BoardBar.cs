using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left, Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();


    public void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 선택이 안됐을 때
        {
            HanoiTower.selectedDonut = PopDonut();
        }
        else // 선택 상태일 때
        {
            PushDonut(HanoiTower.selectedDonut);
        }
    }

    public bool CheckDonut(GameObject donut)
    {
        if (barStack.Count > 0)
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber;
            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if (pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"현재 넣으려는 도넛은 {pushNumber}이고, 해당 기둥의 제일 위의 도넛은 {peekDonut}입니다.");
                return false;
            }
        }
        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
            return;

        HanoiTower.moveCount++;
        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut); // Stack에 GameObject를 넣는 기능
    }



    public GameObject PopDonut()
    {
        if (barStack.Count > 0) 
        {
            HanoiTower.currBar = this;
            HanoiTower.isSelected = true;
            GameObject donut = barStack.Pop();

            return donut;
        }

        Debug.Log("막대에 도넛이 없습니다.");
        return null;
    }
}
