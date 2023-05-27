using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EnemyModel 
{
    public bool IsCashing { get=>isCashing; set=>isCashing=value; }
    public float AttackRange { get => attackRange; }
    public int Damage { get => damage; }
    public bool IsAttacking { get => isAttacking;  }

    private float distanceMax = 10; //ƒ[ƒgƒ‹’PˆÊ
    private float attackRange = 2f;
    private bool isCashing = false;
    private bool isAttacking = true;
    private int damage = 5;
    private float timeRange = 2f;
    private float distance;

    public void DistanceCheck(Transform enemytransform,Transform playertransform)
    {

         distance = Vector3.Distance(enemytransform.position, playertransform.position);
        if (distance<distanceMax)
        {
            IsCashing = true;
        }
    }



    public void OnAttack()
    {
        if (distance < attackRange && isAttacking == true)
        {
            
            isCashing = false;
            isAttacking = false;
            DelayTime();
        }
    }

    async void DelayTime()
    {
        await Task.Delay((int)timeRange * 1000);
        isAttacking = true;
        isCashing = true;
    }
}
