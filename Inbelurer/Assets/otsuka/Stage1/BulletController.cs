using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletDamage = 5;
    public int maxBullets = 10;
    private int currentBullets;
    public float bulletSpeed = 5.0f;
    void Start()
    {
        currentBullets = maxBullets;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentBullets > 0) // 右クリック
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        currentBullets--;
        // 上方向に発射
        Vector3 direction = Vector3.up;

        // 弾に速度を与える
        Bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        // 弾がゼロになったら回復アイテムを生成する
        if (currentBullets == 0)
        {
            FindObjectOfType<Healitem>().StartSpawningAmmo();
        }
    }

    public void AddBullets(int amount)
    {
        currentBullets += amount;
        if (currentBullets > maxBullets)
        {
            currentBullets = maxBullets;
        }
    }
}


