using UnityEngine;
using UnityEngine.AI;

public class Follow_Player : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
}