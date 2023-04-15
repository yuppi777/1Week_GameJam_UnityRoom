using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;
using System;

public class EnemyMove : MonoBehaviour,IEnemy
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    [Header("���̃L�����ɂ��Ă���v���C���[���G�X�N���v�g")]
    private Enemy_PlayerSarch playerSarch;

    private NavMeshAgent agent;

    private bool isChasing;//�v���C���[��ǐՃt���O

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("�_���[�W")]
    private int damage;

    [SerializeField]
    private float attackRange = 2f;

    private bool isAttacking = true;//�U�����ł��邩�ۂ�
    public void Move()
    {
        
    }

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        isChasing = false;
        TrueIsChasing(playerSarch);

        this.FixedUpdateAsObservable()
          .Subscribe(_ =>
          {
              float distance = Vector3.Distance(transform.position, player.position);

              if (distance < attackRange)
              {
                  Debug.Log("�U���͈�");
              }
              if (distance <= attackRange && !isAttacking)
              {
                  Debug.Log("�U��");
                  isAttacking = true;
                  //isChasing = false;
                  AttackPlayer();
              }
              else if (!isAttacking)
              {
                  AttackPlayer();
                  TrueIsChasing(playerSarch);
                  isAttacking = false;
              }
          })
          .AddTo(this);

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

    private void AttackPlayer()
    {
        playerMove.Hp -= damage;

        if (playerMove.Hp <0)
        {
            playerMove.AnLookCus();
            SceneManagement.Instance.SceneChange("GameOver");
        }
        Debug.Log(playerMove.Hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
