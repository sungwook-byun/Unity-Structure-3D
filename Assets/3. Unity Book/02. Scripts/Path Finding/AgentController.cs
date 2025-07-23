using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        agent.SetDestination(points[index].position); // points[0]으로 이동
        if (agent.remainingDistance <= 1.5f)
        {
            Debug.Log("목적지 변경");
            
            int temp = index;
            index = Random.Range(0, points.Length);

            if (temp == index)
                index = (index + 1) % points.Length; // 다음 인덱스로 변경
        }
    }
}
