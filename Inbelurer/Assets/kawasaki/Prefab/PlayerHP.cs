using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject player;
    public  int hp = 3; //プレイヤーのHP
    public static string gameState; //ゲームの状態
    bool inDamage = false; //ダメージ中フラグ
    Rigidbody2D rbody; //Rigidbody2D

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();//Rigidbody2を得る
        //ゲームの状態をプレイ中にする
        gameState = "playing";

    }

    void Update()
    {
        if(hp==0)
        {
            GameOver();
        }

    }


    //接触
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

    //ダメージ
    void GetDamage(GameObject enemy)
    {

        if (gameState == "playing")
        {
            hp--; //を減らす
            if (hp > 0)
            {
                //ダメージフラグON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
        }

    }
    //ダメージ終了
    //void DamageEnd()
    //{
    //    inDamage = false; //ダメージフラグOFF
    //    gameObject.GetComponent<SpriteRenderer>().enabled = true; //スプライトを元に戻す
    //}
    //ゲームオーバー
    void GameOver()
    {
        gameState = "gameover";
        //ゲームオーバー演出
        GetComponent<BoxCollider2D>().enabled = false; //プレイヤーあたりを消す
        Destroy(player, 0.1f); //1秒後にプレイヤーを消す
    }


}
