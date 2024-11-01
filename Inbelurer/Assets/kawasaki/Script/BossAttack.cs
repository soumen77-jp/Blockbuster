using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // �U���̊Ԋu
    private float nextAttackTime;
    public GameObject Attack1;
    public Transform firePoint;
    public Transform player;

    void Start()
    {
        nextAttackTime = Time.time + attackInterval;
    }

    void Update()
    {
        // �U���̃^�C�~���O���`�F�b�N
        if (Time.time >= nextAttackTime)
        {
            PerformRandomAttack();
            nextAttackTime = Time.time + attackInterval; // ���̍U�����Ԃ�ݒ�
        }
    }

    void PerformRandomAttack()
    {
        int attackType = Random.Range(1, 4); // 1����3�̃����_���ȍU���^�C�v��I��

        switch (attackType)
        {
            case 1:
                AttackType1();
                break;
            case 2:
                AttackType2();
                break;
            case 3:
                AttackType3();
                break;
        }
    }

    void AttackType1()
    {
        // �U��1�̏���
        Debug.Log("Enemy Attack Type 1!");

        // �e�𔭎˂��鏈��
        ShootBullet(1.0f, 5f);

    }

    void ShootBullet(float damage,float speed)
    {
        GameObject bullet = Instantiate(Attack1, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = Attack1.GetComponent<Rigidbody2D>();

        Vector3 direction = (player.position - firePoint.position).normalized; // �v���C���[�̕������v�Z
        rb.velocity = direction * speed; // �w�肳�ꂽ���x�Ŕ���

    }


    void AttackType2()
    {
        // �U��2�̏���
        Debug.Log("Enemy Attack Type 2!");
       
    }




    void AttackType3()
    {
        // �U��3�̏���
        Debug.Log("Enemy  Attack Type 3!");
        
    }




}
