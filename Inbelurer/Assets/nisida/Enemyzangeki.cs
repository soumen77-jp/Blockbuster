using System.Collections;
using UnityEngine;

public class Enemyzangeki: MonoBehaviour
{
    public GameObject bulletPrefab; // 発射する弾のプレハブ
    public float attackInterval = 1.0f; // 攻撃の間隔
    public int waveCount = 5; // 波の回数
    public float waveInterval = 0.5f; // 各波の間隔
    public int bulletsPerWave = 5; // 各波で発射する弾の数
    public float bulletSpeed = 5.0f;
    private void Start()
    {
        StartCoroutine(WaveAttack());
    }

    private IEnumerator WaveAttack()
    {
        while (true) // 無限ループ
        {
            for (int wave = 0; wave < waveCount; wave++)
            {
                FireWave(wave);
                yield return new WaitForSeconds(waveInterval); // 各波の間隔
            }
            yield return new WaitForSeconds(attackInterval); // 攻撃の間隔
        }
    }

    private void FireWave(int waveNumber)
    {
        float angleStep = 360f / bulletsPerWave; // 弾の角度の計算

        for (int i = 0; i < bulletsPerWave; i++)
        {
            float angle = i * angleStep + (waveNumber * 15); // 波ごとに角度をずらす
            ShootBullet(angle);
        }
    }

    private void ShootBullet(float angle)
    {
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forward * 5);
        rb.velocity = new Vector2(0, -bulletSpeed);
        //rb.velocity = bullet.transform.forward * 5; // 弾の速度
        
    }
}
