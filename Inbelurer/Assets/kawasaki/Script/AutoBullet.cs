using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : MonoBehaviour
{
    public GameObject bulletPrefab;         // ���˂���e�̃v���n�u
    public Transform firePoint;             // �e�𔭎˂���ʒu
    public float fireRate = 0.5f;           // ���ˊԊu�i�b�j
    private float nextFireTime = 0f;        // ���ɒe�𔭎˂ł��鎞��
    public float damage = 10f;              // �e�̍U����

    void Update()
    {
        // ���݂̎��Ԃ����̔��ˎ��Ԃ𒴂��Ă����甭��
        if (Time.time >= nextFireTime)
        {
            Shoot();  // �e�𔭎�
            nextFireTime = Time.time + fireRate;  // ���̔��ˎ��Ԃ�ݒ�
        }
    }

    void Shoot()
    {
        // �e�𐶐����AfirePoint�̈ʒu�ƌ����Ŕ���
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
