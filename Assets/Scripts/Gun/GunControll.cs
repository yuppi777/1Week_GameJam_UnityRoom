using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    [SerializeField]
    [Header("íe")]
    private GameObject bulletprefab;
    [SerializeField]
    [Header("èeå˚")]
    private Transform shotArea;

    
    

    private Rigidbody bulletRb;

    void Start()
    {
        
    }
   

    private void BulletShot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.Instance.PlaySE("shot");
          GameObject prefab= Instantiate(bulletprefab, shotArea.position, Quaternion.identity);
            //prefab.transform.Rotate(-90, 0, 0);
            prefab.transform.Rotate(Camera.main.transform.eulerAngles);

        }
       
    }
    // Update is called once per frame
    void Update()
    {
        BulletShot();
        
    }
}
