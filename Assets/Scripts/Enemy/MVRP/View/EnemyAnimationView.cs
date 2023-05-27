using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationView : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    [Header("���񂾎��ɏo��p�[�e�B�N��")]
    private GameObject particlePrefab; //�̂��̂�ParticleSystem�ɕύX
    void Start()
    {
        animator = GetComponent<Animator>();   
    }
    /// <summary>
    /// DeathAnimation�J�n���ɌĂ΂��
    /// </summary>
    public void DeathAnimationPlay()
    {
       NavMeshAgent agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent .updatePosition = false;
        GameObject par;
        par = Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
        par.transform.parent = this.transform;


    }

    /// <summary>
    /// DeathAnimation�I�����ɌĂ΂��
    /// </summary>
    public void DeathAnimationEnd()
    {
        
        AudioManager.Instance.PlaySE("Down");
        Destroy(this.gameObject);
    }

    public void isAttack(bool isattack)
    {
        animator.SetBool("isAttack", isattack);
        
    }

    public void isPlayerLook(bool isplayerLook)
    {
        animator.SetBool("isPlayerLook", isplayerLook);
    }

}
