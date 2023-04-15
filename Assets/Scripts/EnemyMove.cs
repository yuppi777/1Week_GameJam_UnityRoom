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
    [Header("このキャラについているプレイヤー索敵スクリプト")]
    private Enemy_PlayerSarch playerSarch;

    private NavMeshAgent agent;

    private bool isChasing;//プレイヤーを追跡フラグ

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("ダメージ")]
    private int damage;

    [SerializeField]
    private float attackRange = 2f;

    private bool isAttacking = true;//攻撃中であるか否か
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
                  Debug.Log("攻撃範囲");
              }
              if (distance <= attackRange && !isAttacking)
              {
                  Debug.Log("攻撃");
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
