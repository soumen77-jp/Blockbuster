using System.Collections;
using UnityEngine;

public class Enemyzangeki: MonoBehaviour
{
    public GameObject bulletPrefab; // ���˂���e�̃v���n�u
    public float attackInterval = 1.0f; // �U���̊Ԋu
    public int waveCount = 5; // �g�̉�
    public float waveInterval = 0.5f; // �e�g�̊Ԋu
    public int bulletsPerWave = 5; // �e�g�Ŕ��˂���e�̐�
    public float bulletSpeed = 5.0f;
    private void Start()
    {
        StartCoroutine(WaveAttack());
    }

    private IEnumerator WaveAttack()
    {
        while (true) // �������[�v
        {
            for (int wave = 0; wave < waveCount; wave++)
            {
                FireWave(wave);
                yield return new WaitForSeconds(waveInterval); // �e�g�̊Ԋu
            }
            yield return new WaitForSeconds(attackInterval); // �U���̊Ԋu
        }
    }

    private void FireWave(int waveNumber)
    {
        float angleStep = 360f / bulletsPerWave; // �e�̊p�x�̌v�Z

        for (int i = 0; i < bulletsPerWave; i++)
        {
            float angle = i * angleStep + (waveNumber * 15); // �g���ƂɊp�x�����炷
            ShootBullet(angle);
        }
    }

    private void ShootBullet(float angle)
    {
        // �e�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forward * 5);
        rb.velocity = new Vector2(0, -bulletSpeed);
        //rb.velocity = bullet.transform.forward * 5; // �e�̑��x
        
    }
}
