using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public GameObject player;

    public float speed = 3.0f; //�ړ��X�s�[�h
    float axisH; //����
    float axisV; //�c��
    Rigidbody2D rbody; //Rigidbody2D
    //�_���[�W�Ή�
    public static int hp = 3; //�v���C���[��HP
    public static string gameState; //�Q�[���̏��
    bool inDamage = false; //�_���[�W���t���O

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Rigidbody2�𓾂�
        //�Q�[���̏�Ԃ��v���C���ɂ���
        gameState = "playing";

    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal"); //���E�L�[����
        axisV = Input.GetAxisRaw("Vertical"); //�㉺�L�[����

        if (hp == 0)
        {
            GameOver();
        }
    }

    void FixedUpdate()
    {
        //�ړ����x���X�V����
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

    //�ڐG
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage1(collision.gameObject);
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

    void GetDamage1(GameObject enemy)
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
