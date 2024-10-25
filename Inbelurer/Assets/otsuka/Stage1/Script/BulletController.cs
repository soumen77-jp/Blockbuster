using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Text ammoText;
    public int bulletDamage = 5;
    public int maxBullets = 10;
    private int currentBullets;
    public float bulletSpeed = 1.0f;

    void Start()
    {
        currentBullets = maxBullets;
        UpdateAmmoText();
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
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed; // 弾を上方向に発射

        currentBullets--;
        UpdateAmmoText();
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
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "残り弾数: " + currentBullets;
    }
}


