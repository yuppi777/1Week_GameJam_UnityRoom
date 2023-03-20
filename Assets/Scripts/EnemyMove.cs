using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour,IEnemy
{
    [SerializeField]
    private Transform player;

    private NavMeshAgent agent;

    private bool isChasing;//プレイヤーを追跡フラグ

    [SerializeField]
    private float speed;

    public void Move()
    {
        
    }

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            Debug.Log("呼ばれた");
        }
    }
}
