using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    // 화살을 발사하는 기능
    // 화살
    // 발사할 위치
    // 화살이 날아가는 기능 -> Arrow 스크립트로 작성

    public GameObject arrowPrefab; // 화살 프리팹
    public Transform shootPos; // 화살이 발사될 위치
    public bool isShoot;


    private void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // 레이저 닿은 대상

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootPos.position, shootPos.forward, Color.green); // 레이저 시각화

        if (isTargeting && !isShoot)
            StartCoroutine(ShootRoutine()); // 레이저가 닿으면 ShootRoutine 코루틴 실행 
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0)); // 화살의 회전 설정  
        arrow.transform.SetPositionAndRotation(shootPos.position, rot); // 화살이 발사될 위치와 회전 설정

        yield return new WaitForSeconds(3f); // 3초 대기
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f); // 화살이 발사될 위치에서 레이저 시각화
    }
}
