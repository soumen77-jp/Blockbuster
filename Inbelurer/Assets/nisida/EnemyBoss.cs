using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
   
        public GameObject bulletPrefab;       // �e��Prefab
        public Transform firePoint;           // �e�𔭎˂���ʒu
        public float health = 100f;           // �{�X��HP
        public float attackCooldown = 2f;     // �U���̃N�[���_�E������
        private bool isAttacking = false;     // �U�������ǂ���

        private void Start()
        {
            StartCoroutine(AttackRoutine());  // �U���̃��[�`�����J�n
        }

        private void Update()
        {
            if (health <= 0f)
            {
                Die(); // �{�X�̎��S����
            }
        }

        // �{�X�̎��S����
        private void Die()
        {
            // ���S�A�j���[�V������G�t�F�N�g��ǉ��\
            Destroy(gameObject); // �{�X���폜
        }

        // �U���p�^�[�������I�ɕύX���郋�[�`��
        private IEnumerator AttackRoutine()
        {
            while (true)
            {
                if (!isAttacking)
                {Random
                    isAttacking = true;
                    // �����_���ōU���p�^�[����؂�ւ���
                    int pattern = .Range(0, 3);
                    switch (pattern)
                    {
                        case 0:
                            StartCoroutine(ShootStraight());  // �����U��
                            break;
                        case 1:
                            StartCoroutine(ShootCircular()); // �~�`�U��
                            break;
                        case 2:
                            StartCoroutine(ShootSpread());   // �g�U�U��
                            break;
                    }
                    yield return new WaitForSeconds(attackCooldown);
                    isAttacking = false;
                }
                yield return null;
            }
        }

        // �����I�ɒe�𔭎˂���U��
        private IEnumerator ShootStraight()
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(0.2f); // �e���Ԋu���J���Ĕ���
            }
        }

        // �~�`�ɒe����U��
        private IEnumerator ShootCircular()
        {
            int bulletCount = 8;
            float angleStep = 360f / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * angleStep;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                Instantiate(bulletPrefab, firePoint.position, rotation);
                yield return new WaitForSeconds(0.1f); // �Ԋu���J���Ĕ���
            }
        }

        // �e����ˏ�Ɋg�U����U��
        private IEnumerator ShootSpread()
        {
            int bulletCount = 5;
            float angleStep = 30f; // �e�̊Ԋu��30�x�ɐݒ�
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - 2) * angleStep; // ���S����-60�x~60�x�ɔ���
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                Instantiate(bulletPrefab, firePoint.position, rotation);
                yield return new WaitForSeconds(0.2f); // �Ԋu���J���Ĕ���
            }
        }
    
}
