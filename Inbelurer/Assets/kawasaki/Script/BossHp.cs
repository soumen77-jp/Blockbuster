using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public int BossHP;

    void OnTriggerEnter2D(Collider2D other)
    {
        //当たったのがBulletだったら
        if(other.gameObject.CompareTag("FriendBullet"))
        {
            //体力を１減らす
            BossHP -= 1;

            //弾を削除する
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            //体力を１減らす
            BossHP -= 1;

            //ミサイルを削除する
            Destroy(other.gameObject);

        }



        if (BossHP==0)
        {
            //オブジェクト破壊する
            Destroy(transform.root.gameObject);

        }

    }

}
