//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BossEnemyShip : MonoBehaviour
//{
//    // 8方向に弾をうつ
//    // ・1方向に弾をうつ
//    // ・好きな角度に弾をうつ：
//    // ・360°を8分割して、弾を発射する

//    // 一定間隔で実行する
//    // ・コルーチン：時間の制御がめっちゃ楽になるもの

//    // 敵の行動を管理する
//    // ・コルーチン

//    // 特定の位置まで移動
//    // ・Bossの生成
//    // ・特定の位置まで移動する
//    // ・移動してから攻撃する

//    // 弾幕の実装
//    // ・幾何学模様
//    // ・Playerを狙う


//    GameObject player;
//    public BossEnemyBullet bulletPrefab;

//    //*********************************
//    //爆破エフェクト
//    public GameObject explosion;
//    //GameControllerのAddScoreメソッドを使用するため入れ物を用意
//    GameController gameController;

//    int Hp = 10;
//    //*********************************

//    void Start()
//    {
//        player = GameObject.Find("PlayerShip");
//        StartCoroutine(CPU());

//        //*******************************
//        //GameObject.Find("")でカッコ内のオブジェクトを取得し、GetComponentでそのオブジェクトの指定した部品を取得してくる
//        gameController = GameObject.Find("GameController").GetComponent<GameController>();
//        //*******************************
//    }

//    void Shot(float angle, float speed)
//    {
//        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
//        bullet.Setting(angle, speed); // Mathf.PI/4fは45°
//    }

//    IEnumerator CPU()
//    {
//        // 特定の位置より上だったら
//        while (transform.position.y > 1f)
//        {
//            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
//            yield return null; //1フレーム(0.02秒)待つ 
//        }

//        // while(カッコの中がtrueの間繰り返し処理をする)
//        while (true)
//        {
//            yield return WaveNShotM(4, 8);
//            yield return new WaitForSeconds(1f);
//            yield return WaveNShotMCurve(4, 16);
//            yield return new WaitForSeconds(1f);
//            yield return WaveNPlayerAimShot(4, 6);
//            yield return new WaitForSeconds(1f);
//        }
//    }

//    IEnumerator WaveNShotM(int n, int m)
//    {
//        // 4回8方向に撃ちたい
//        for (int w = 0; w < n; w++)
//        {
//            yield return new WaitForSeconds(0.3f);
//            ShotN(m, 2);
//        }
//    }
//    IEnumerator WaveNShotMCurve(int n, int m)
//    {
//        // 4回8方向に撃ちたい
//        for (int w = 0; w < n; w++)
//        {
//            yield return new WaitForSeconds(0.3f);
//            yield return ShotNCurve(m, 2);
//        }
//    }
//    IEnumerator WaveNPlayerAimShot(int n, int m)
//    {
//        // 4回8方向に撃ちたい
//        for (int w = 0; w < n; w++)
//        {
//            yield return new WaitForSeconds(1f);
//            PlayerAimShot(m, 3);
//        }
//    }

//    void ShotN(int count, float speed)
//    {
//        int bulletCount = count;
//        for (int i = 0; i < bulletCount; i++)
//        {
//            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
//            Shot(angle, speed);
//        }
//    }

//    IEnumerator ShotNCurve(int count, float speed)
//    {
//        int bulletCount = count;
//        for (int i = 0; i < bulletCount; i++)
//        {
//            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
//            Shot(angle - Mathf.PI / 2f, speed);
//            Shot(-angle - Mathf.PI / 2f, speed);
//            yield return new WaitForSeconds(0.1f);
//        }
//    }

//    // Playerを狙う
//    // ・Playerの位置取得
//    // ・どの角度に撃てばいいのかを計算
//    void PlayerAimShot(int count, float speed)
//    {
//        //この弾幕前にplayerが倒されていたら何もしない
//        if (player != null)
//        {
//            // 自分からみたPlayerの位置を計算する
//            Vector3 diffPosition = player.transform.position - transform.position;
//            // 自分から見たPlayerの角度を出す：傾きから角度を出す：アークタンジェントを使う
//            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

//            int bulletCount = count;
//            for (int i = 0; i < bulletCount; i++)
//            {
//                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2f：90


//                Shot(angleP + angle, speed);
//            }
//        }

//    }

//    //****************************
//    //Bossの当たり判定
//    public void OnTriggerEnter2D(Collider2D collision)
//    {
//        //playerとBossが接触した時
//        if (collision.CompareTag("Player") == true)
//        {
//            //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
//            Instantiate(explosion, collision.transform.position, transform.rotation);
//            //collisionはぶつかった相手の情報が入っている。
//            Destroy(collision.gameObject);

//            gameController.GameOver();
//        }
//        //BulletとBossが接触した時
//        else if (collision.CompareTag("Bullet") == true)
//        {
//            //BossのHp
//            Hp--;

//            //collisionはぶつかった相手の情報が入っている。この場合は弾
//            Destroy(collision.gameObject);

//            if (Hp <= 0)
//            {
//                //enemyの機体を破壊
//                Destroy(gameObject);
//                //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
//                Instantiate(explosion, transform.position, transform.rotation);
//            }

//        }

//    }
//    //******************************

//}