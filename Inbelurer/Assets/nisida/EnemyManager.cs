using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShip : MonoBehaviour
{
    // 8�����ɒe������
    // �E1�����ɒe������
    // �E�D���Ȋp�x�ɒe�����F
    // �E360����8�������āA�e�𔭎˂���

    // ���Ԋu�Ŏ��s����
    // �E�R���[�`���F���Ԃ̐��䂪�߂�����y�ɂȂ����

    // �G�̍s�����Ǘ�����
    // �E�R���[�`��

    // ����̈ʒu�܂ňړ�
    // �EBoss�̐���
    // �E����̈ʒu�܂ňړ�����
    // �E�ړ����Ă���U������

    // �e���̎���
    // �E�􉽊w�͗l
    // �EPlayer��_��


    GameObject player;
    public BossEnemyBullet bulletPrefab;

    //*********************************
    //���j�G�t�F�N�g
    public GameObject explosion;
    //GameController��AddScore���\�b�h���g�p���邽�ߓ��ꕨ��p��
    GameController gameController;

    int Hp = 10;
    //*********************************

    void Start()
    {
        player = GameObject.Find("PlayerShip");
        StartCoroutine(CPU());

        //*******************************
        //GameObject.Find("")�ŃJ�b�R���̃I�u�W�F�N�g���擾���AGetComponent�ł��̃I�u�W�F�N�g�̎w�肵�����i���擾���Ă���
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //*******************************
    }

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed); // Mathf.PI/4f��45��
    }

    IEnumerator CPU()
    {
        // ����̈ʒu���ゾ������
        while (transform.position.y > 1f)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null; //1�t���[��(0.02�b)�҂� 
        }

        // while(�J�b�R�̒���true�̊ԌJ��Ԃ�����������)
        while (true)
        {
            yield return WaveNShotM(4, 8);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotMCurve(4, 16);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(4, 6);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        // 4��8�����Ɍ�������
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 2);
        }
    }
    IEnumerator WaveNShotMCurve(int n, int m)
    {
        // 4��8�����Ɍ�������
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 2);
        }
    }
    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        // 4��8�����Ɍ�������
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 3);
        }
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI�F360
            Shot(angle, speed);
        }
    }

    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI�F360
            Shot(angle - Mathf.PI / 2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Player��_��
    // �EPlayer�̈ʒu�擾
    // �E�ǂ̊p�x�Ɍ��Ă΂����̂����v�Z
    void PlayerAimShot(int count, float speed)
    {
        //���̒e���O��player���|����Ă����牽�����Ȃ�
        if (player != null)
        {
            // ��������݂�Player�̈ʒu���v�Z����
            Vector3 diffPosition = player.transform.position - transform.position;
            // �������猩��Player�̊p�x���o���F�X������p�x���o���F�A�[�N�^���W�F���g���g��
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2f�F90


                Shot(angleP + angle, speed);
            }
        }

    }

    //****************************
    //Boss�̓����蔻��
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //player��Boss���ڐG������
        if (collision.CompareTag("Player") == true)
        {
            //�j�󂷂鎞�ɔ��j�G�t�F�N�g�����i�������������́A�ꏊ�A��]�j
            Instantiate(explosion, collision.transform.position, transform.rotation);
            //collision�͂Ԃ���������̏�񂪓����Ă���B
            Destroy(collision.gameObject);

            gameController.GameOver();
        }
        //Bullet��Boss���ڐG������
        else if (collision.CompareTag("Bullet") == true)
        {
            //Boss��Hp
            Hp--;

            //collision�͂Ԃ���������̏�񂪓����Ă���B���̏ꍇ�͒e
            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                //enemy�̋@�̂�j��
                Destroy(gameObject);
                //�j�󂷂鎞�ɔ��j�G�t�F�N�g�����i�������������́A�ꏊ�A��]�j
                Instantiate(explosion, transform.position, transform.rotation);
            }

        }

    }
    //******************************

}