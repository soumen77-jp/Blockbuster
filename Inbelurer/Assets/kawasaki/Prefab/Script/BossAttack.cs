using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // UŒ‚‚ÌŠÔŠu
    private float nextAttackTime;
    public GameObject Attack1;
    public GameObject Attack2;
    public Transform firePoint;
    public Transform player;
    public float Attack1Speed = 5f;
    public float Attack1Angle = 15f;
    public int Attack2bulletCount = 5;        // U’e‚Ì”
    public float Attack2spreadAngle = 45f;    // U’e‚ÌL‚ª‚éŠp“x
    public float Attack2bulletSpeed = 10f;    // ’e‚ÌƒXƒs[ƒh

    void Start()
    {
        nextAttackTime = Time.time + attackInterval;
    }

    void Update()
    {
        // UŒ‚‚Ìƒ^ƒCƒ~ƒ“ƒO‚ğƒ`ƒFƒbƒN
        if (Time.time >= nextAttackTime)
        {
            PerformRandomAttack();
            nextAttackTime = Time.time + attackInterval; // Ÿ‚ÌUŒ‚ŠÔ‚ğİ’è
        }
    }

    void PerformRandomAttack()
    {
        int attackType = Random.Range(1, 4); // 1‚©‚ç3‚Ìƒ‰ƒ“ƒ_ƒ€‚ÈUŒ‚ƒ^ƒCƒv‚ğ‘I‘ğ

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
    //---------------ãUŒ‚------------------------
    //---------------------------------------------


    void AttackType1()
    {
        // UŒ‚1‚Ìˆ—
        Debug.Log("Enemy Attack  1");

        Shoot();

    }
    public void Shoot()
    {
        // ’†‰›A¶A‰E‚Ì’e‚ğ¶¬
        FireProjectile(Vector2.down); // ^‰º
        FireProjectile(Quaternion.Euler(0, 0, -Attack1Angle) * Vector2.down); // ¶•ûŒü
        FireProjectile(Quaternion.Euler(0, 0, Attack1Angle) * Vector2.down);  // ‰E•ûŒü
    }

    private void FireProjectile(Vector2 direction)
    {
        // ’e‚ğ¶¬
        GameObject projectile = Instantiate(Attack1, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // ’e‚É‘¬“x‚ğ—^‚¦‚é
        if (rb != null)
        {
            rb.velocity = direction.normalized * Attack1Speed;
        }
    }


    //---------------------------------------------
    //---------------’†UŒ‚------------------------
    //---------------------------------------------


    void AttackType2()
    {
        Debug.Log("Enemy  Attack  2");

        ShootBullets();
    }

    private void ShootBullets()
    {
        for (int i = 0; i < Attack2bulletCount; i++)
        {
            float angle = i * (360f / Attack2bulletCount) + Time.time * 30f; // ŠÔ‚É‰‚¶‚ÄŠp“x‚ğ‘‰Á
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