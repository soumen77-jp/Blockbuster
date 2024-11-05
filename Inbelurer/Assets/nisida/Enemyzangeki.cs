using System.Collections;
using UnityEngine;

public class Enemyzangeki: MonoBehaviour
{
    public GameObject bulletPrefab; // ”­Ë‚·‚é’e‚ÌƒvƒŒƒnƒu
    public float attackInterval = 1.0f; // UŒ‚‚ÌŠÔŠu
    public int waveCount = 5; // ”g‚Ì‰ñ”
    public float waveInterval = 0.5f; // Še”g‚ÌŠÔŠu
    public int bulletsPerWave = 5; // Še”g‚Å”­Ë‚·‚é’e‚Ì”
    public float bulletSpeed = 5.0f;
    private void Start()
    {
        StartCoroutine(WaveAttack());
    }

    private IEnumerator WaveAttack()
    {
        while (true) // –³ŒÀƒ‹[ƒv
        {
            for (int wave = 0; wave < waveCount; wave++)
            {
                FireWave(wave);
                yield return new WaitForSeconds(waveInterval); // Še”g‚ÌŠÔŠu
            }
            yield return new WaitForSeconds(attackInterval); // UŒ‚‚ÌŠÔŠu
        }
    }

    private void FireWave(int waveNumber)
    {
        float angleStep = 360f / bulletsPerWave; // ’e‚ÌŠp“x‚ÌŒvZ

        for (int i = 0; i < bulletsPerWave; i++)
        {
            float angle = i * angleStep + (waveNumber * 15); // ”g‚²‚Æ‚ÉŠp“x‚ğ‚¸‚ç‚·
            ShootBullet(angle);
        }
    }

    private void ShootBullet(float angle)
    {
        // ’e‚ğ¶¬
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forward * 5);
        rb.velocity = new Vector2(0, -bulletSpeed);
        //rb.velocity = bullet.transform.forward * 5; // ’e‚Ì‘¬“x
        
    }
}
