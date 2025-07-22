using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    private float curSpeed;
    private Vector3 targetPoint;
    public float steeringForce = 10f;

    private void Start()
    {
        targetPoint = Vector3.zero;
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                targetPoint = hit.point; // 마우스 클릭한 곳이 목표 지점으로 설정
        }

        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir); // 장애물 회피 방향 계산

        if (Vector3.Distance(targetPoint, transform.position) < 1f)
            return;

        curSpeed = speed * Time.deltaTime;
        transform.position += transform.forward * curSpeed; // 이동 방향으로 속도만큼 이동

        Quaternion rot = Quaternion.LookRotation(dir); // 방향을 알려주는 백터를 넣으면 그 방향을 보는 값을 설정
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime); // 회전 속도 설정
    }

    // 이동 방향에 장애물이 있을 경우 이동하려는 방향을 바꾸는 기능
    public Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 15;
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0; // 수평면에서만 회피 방향 계산

            dir = transform.forward + hitNormal * force;
            dir.Normalize();
        }
        return dir;
    }
}
