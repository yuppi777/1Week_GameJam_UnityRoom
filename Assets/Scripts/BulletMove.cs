using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    private Rigidbody _thisBulletRb;

    [SerializeField]
    private float speed;

    

    private void Awake()
    {
        
        try
        {
           _thisBulletRb = this.gameObject.GetComponent<Rigidbody>();
        }
        catch (System.Exception)
        {
            this.gameObject.AddComponent<Rigidbody>();
            _thisBulletRb = this.gameObject.GetComponent<Rigidbody>();
        }   
    }
    void Start()
    {
        BulletAddForce();
    }


    private void BulletAddForce()
    {
        _thisBulletRb.AddForce(this.gameObject.transform.forward * speed );
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
           
            Debug.Log("�G�ɐG�ꂽ");
            Destroy(collision.gameObject);//�G���f�X�g���C
            Destroy(this.gameObject);//�e���g���f�X�g���C
        }
    }
    void Update()
    {
        
    }
}
