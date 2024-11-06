using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject player;
    public  int hp = 3; //�v���C���[��HP
    public static string gameState; //�Q�[���̏��
    bool inDamage = false; //�_���[�W���t���O
    Rigidbody2D rbody; //Rigidbody2D

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Rigidbody2�𓾂�
        //�Q�[���̏�Ԃ��v���C���ɂ���
        gameState = "playing";

    }

    void Update()
    {
        if(hp==0)
        {
            GameOver();
        }

    }


    //�ڐG
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage(collision.gameObject);
        }
    }

    //�_���[�W
    void GetDamage(GameObject enemy)
    {

        if (gameState == "playing")
        {
            hp--; //�����炷
            if (hp > 0)
            {
                //�_���[�W�t���OON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
        }

    }
    //�_���[�W�I��
    //void DamageEnd()
    //{
    //    inDamage = false; //�_���[�W�t���OOFF
    //    gameObject.GetComponent<SpriteRenderer>().enabled = true; //�X�v���C�g�����ɖ߂�
    //}
    //�Q�[���I�[�o�[
    void GameOver()
    {
        gameState = "gameover";
        //�Q�[���I�[�o�[���o
        GetComponent<BoxCollider2D>().enabled = false; //�v���C���[�����������
        Destroy(player, 0.1f); //1�b��Ƀv���C���[������
    }


}
