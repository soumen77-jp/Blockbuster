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
        if (Input.GetMouseButtonDown(1) && currentBullets > 0) // �E�N���b�N
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        currentBullets--;
        // ������ɔ���
        Vector3 direction = Vector3.up;

        // �e�ɑ��x��^����
        Bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        // �e���[���ɂȂ�����񕜃A�C�e���𐶐�����
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


