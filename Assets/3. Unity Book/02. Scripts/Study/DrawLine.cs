using NUnit.Framework;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line; // 생성된 라인 렌더러
    private int lineCount = 0;
    private int lineObjectCount = 1;

    public Color color;
    public float lineWidth = 0.05f;
    
    public List<GameObject> lineObjs = new List<GameObject>();

    private void Start()
    {
        color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        // 선 그리기 시작
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            GameObject lineObject = new GameObject("LineObject"); // 빈 게임 오브젝트 생성
            lineObjectCount++;

            line = lineObject.AddComponent<LineRenderer>(); // 라인렌더러 추가하여 현재 조작할 line 설정
            line.useWorldSpace = false;
            line.startWidth = lineWidth; // 라인 시작 너비 설정
            line.endWidth = lineWidth; // 라인 끝 너비 설정

            line.startColor = color; // 라인 시작 색상 설정
            line.endColor = color; // 라인 끝 색상 설정

            line.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit")); // 라인 렌더러에 사용할 머티리얼 설정

            lineObjs.Add(lineObject); // 생성된 라인 오브젝트를 리스트에 추가
        }
        
        if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼을 누르고 있는 동안
        {
            Vector3 screenPos = Input.mousePosition; // 마우스 위치를 화면 좌표로 가져옴
            screenPos.z = 10f; // 카메라와의 거리 설정 (10 유닛 앞에 위치)
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // 화면 좌표를 월드 좌표로 변환

            lineCount++;
            line.positionCount = lineCount; // 라인 렌더러의 점 개수 설정
            line.SetPosition(lineCount - 1, worldPos); // 현재 마우스 위치를 라인 렌더러에 추가
        }

        if (Input.GetMouseButtonUp(0)) // 마우스 왼쪽 버튼을 떼면
        {
            lineCount = 0; // 라인 점 개수 초기화
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 누르면
        {
            foreach (var line in lineObjs) // 생성된 모든 라인 오브젝트를 순회
                Destroy(line); // 라인 오브젝트 삭제

            lineObjs.Clear(); // 리스트 초기화
        }
    }
}
