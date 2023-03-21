using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;

public class EnemyMove : MonoBehaviour,IEnemy
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    [Header("���̃L�����ɂ��Ă���v���C���[���G�X�N���v�g")]
    private Enemy_PlayerSarch playerSarch;

    private NavMeshAgent agent;

    private bool isChasing;//�v���C���[��ǐՃt���O

    [SerializeField]
    private float speed;

    public void Move()
    {
        
    }

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        isChasing = false;
        TrueIsChasing(playerSarch);

    }

    private void TrueIsChasing(Enemy_PlayerSarch playerSarch)
    {
        playerSarch.ObserveEveryValueChanged(playerSarch =>playerSarch.PlayerOn)
            .Subscribe(value =>
            {
                 isChasing = value;
            })
            .AddTo(gameObject);

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
        
    }
}
