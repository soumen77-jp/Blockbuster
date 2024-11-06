using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // �U���̊Ԋu
    private float nextAttackTime;
    public GameObject Attack1;
    public GameObject Attack2;
    public Transform firePoint;
    public Transform player;
    public float Attack1Speed = 5f;
    public float Attack1Angle = 15f;
    public int Attack2bulletCount = 5;        // �U�e�̐�
    public float Attack2spreadAngle = 45f;    // �U�e�̍L����p�x
    public float Attack2bulletSpeed = 10f;    // �e�̃X�s�[�h

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
                AttackType2();
                break;


        }
    }


    //---------------------------------------------
    //---------------��U��------------------------
    //---------------------------------------------


    void AttackType1()
    {
        // �U��1�̏���
        Debug.Log("Enemy Attack  1");

        Shoot();

    }
    public void Shoot()
    {
        // �����A���A�E�̒e�𐶐�
        FireProjectile(Vector2.down); // �^��
        FireProjectile(Quaternion.Euler(0, 0, -Attack1Angle) * Vector2.down); // ������
        FireProjectile(Quaternion.Euler(0, 0, Attack1Angle) * Vector2.down);  // �E����
    }

    private void FireProjectile(Vector2 direction)
    {
        // �e�𐶐�
        GameObject projectile = Instantiate(Attack1, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // �e�ɑ��x��^����
        if (rb != null)
        {
            rb.velocity = direction.normalized * Attack1Speed;
        }
    }


    //---------------------------------------------
    //---------------���U��------------------------
    //---------------------------------------------


    void AttackType2()
    {
        Debug.Log("Enemy  Attack  2");

        ShootBullets();
    }

    private void ShootBullets()
    {
        for (int i = 0; i < Attack2bulletCount; i++)
        {
            float angle = i * (360f / Attack2bulletCount) + Time.time * 30f; // ���Ԃɉ����Ċp�x�𑝉�
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

            GameObject bullet = Instantiate(Attack2, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * Attack2bulletSpeed;
        }
    }





    void AttackType3()
    {
        Debug.Log("Enemy  Attack  3");

       
    }

}