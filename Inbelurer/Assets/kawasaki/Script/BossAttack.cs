using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // 攻撃の間隔
    private float nextAttackTime;
    public GameObject Attack1;
    public Transform firePoint;
    public Transform player;

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
                AttackType3();
                break;
        }
    }

    void AttackType1()
    {
        // 攻撃1の処理
        Debug.Log("Enemy Attack Type 1!");

        // 弾を発射する処理
        ShootBullet(1.0f, 5f);

    }

    void ShootBullet(float damage,float speed)
    {
        GameObject bullet = Instantiate(Attack1, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = Attack1.GetComponent<Rigidbody2D>();

        Vector3 direction = (player.position - firePoint.position).normalized; // プレイヤーの方向を計算
        rb.velocity = direction * speed; // 指定された速度で発射

    }


    void AttackType2()
    {
        // 攻撃2の処理
        Debug.Log("Enemy Attack Type 2!");
       
    }




    void AttackType3()
    {
        // 攻撃3の処理
        Debug.Log("Enemy  Attack Type 3!");
        
    }




}
