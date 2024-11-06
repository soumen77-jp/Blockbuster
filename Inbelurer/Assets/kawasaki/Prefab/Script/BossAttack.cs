using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // 攻撃の間隔
    private float nextAttackTime;
    public GameObject Attack1;
    public GameObject Attack2;
    public Transform firePoint;
    public Transform player;
<<<<<<< HEAD:Inbelurer/Assets/kawasaki/Prefab/Script/BossAttack.cs
    public float Attack1Speed = 5f;
    public float Attack1Angle = 15f;
=======
    public float Attack1bulletSpeed = 10f; // 弾の速度
>>>>>>> new:Inbelurer/Assets/kawasaki/Script/BossAttack.cs
    public int Attack2bulletCount = 5;        // 散弾の数
    public float Attack2spreadAngle = 45f;    // 散弾の広がる角度
    public float Attack2bulletSpeed = 10f;    // 弾のスピード

    void Start()
    {
        nextAttackTime = Time.time + attackInterval;
    }

    void Update()
    {
        // 攻撃のタイミングをチェック
        if (Time.time >= nextAttackTime)
        {
            PerformRandomAttack();
            nextAttackTime = Time.time + attackInterval; // 次の攻撃時間を設定
        }
    }

    void PerformRandomAttack()
    {
        int attackType = Random.Range(1, 4); // 1から3のランダムな攻撃タイプを選択

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
    //---------------弱攻撃------------------------
    //---------------------------------------------


    void AttackType1()
    {
        // 攻撃1の処理
        Debug.Log("Enemy Attack  1");

<<<<<<< HEAD:Inbelurer/Assets/kawasaki/Prefab/Script/BossAttack.cs
        Shoot();

    }
    public void Shoot()
    {
        // 中央、左、右の弾を生成
        FireProjectile(Vector2.down); // 真下
        FireProjectile(Quaternion.Euler(0, 0, -Attack1Angle) * Vector2.down); // 左方向
        FireProjectile(Quaternion.Euler(0, 0, Attack1Angle) * Vector2.down);  // 右方向
    }

    private void FireProjectile(Vector2 direction)
    {
        // 弾を生成
        GameObject projectile = Instantiate(Attack1, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // 弾に速度を与える
        if (rb != null)
        {
            rb.velocity = direction.normalized * Attack1Speed;
        }
    }


    //---------------------------------------------
    //---------------中攻撃------------------------
    //---------------------------------------------


=======
        ShootTripleShot();
    }

    private void ShootTripleShot()
    {
        // 中央下方向の弾を発射
        ShootBullet(0);

        // 左下方向の弾を発射（-30度）
        ShootBullet(-30);

        // 右下方向の弾を発射（30度）
        ShootBullet(30);
    }

    private void ShootBullet(float angleOffset)
    {
        // 下方向を基準にして角度を設定
        Vector2 direction = Quaternion.Euler(0, 0, angleOffset) * Vector2.down;

        // 弾を生成して速度を設定
        GameObject bullet = Instantiate(Attack1, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * Attack1bulletSpeed;
    }



    //中攻撃
>>>>>>> new:Inbelurer/Assets/kawasaki/Script/BossAttack.cs
    void AttackType2()
    {
        Debug.Log("Enemy  Attack  2");

        ShootBullets();
    }

    private void ShootBullets()
    {
        for (int i = 0; i < Attack2bulletCount; i++)
        {
            float angle = i * (360f / Attack2bulletCount) + Time.time * 30f; // 時間に応じて角度を増加
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