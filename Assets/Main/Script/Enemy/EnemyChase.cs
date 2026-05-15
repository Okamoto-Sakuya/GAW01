using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    // 速度の範囲
    public float minSpeed = 2f;
    public float maxSpeed = 6f;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        agent = GetComponent<NavMeshAgent>();

        // ?ここがポイント：ランダム速度付与
        agent.speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        if (player == null) return;

        if (agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
        }
    }
}