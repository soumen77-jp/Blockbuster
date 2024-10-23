using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int moveSpeed = 5;

    //�Q�[���I�u�W�F�N�g���擾
    public GameObject bulletPrefab;
    public GameObject firingPosition;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        OffScreen();
    }

    //Enemy�����ړ�������
    private void Move() => transform.position +=
            new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

    //Enemy����ʊO�ɏo������ł�����
    private void OffScreen()
    {


        if (this.transform.position.y > -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //Bullet�𐶐�
    private void Shot()
    {
        Instantiate(
            bulletPrefab,
            firingPosition.transform.position,
            transform.rotation);
    }
}
