using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public int BossHP;

    void OnTriggerEnter2D(Collider2D other)
    {
        //���������̂�Bullet��������
        if(other.gameObject.CompareTag("FriendBullet"))
        {
            //�̗͂��P���炷
            BossHP -= 1;

            //�e���폜����
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            //�̗͂��P���炷
            BossHP -= 1;

            //�~�T�C�����폜����
            Destroy(other.gameObject);

        }



        if (BossHP==0)
        {
            //�I�u�W�F�N�g�j�󂷂�
            Destroy(transform.root.gameObject);

        }

    }

}
