using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
   
        public GameObject bulletPrefab;       // 弾のPrefab
        public Transform firePoint;           // 弾を発射する位置
        public float health = 100f;           // ボスのHP
        public float attackCooldown = 2f;     // 攻撃のクールダウン時間
        private bool isAttacking = false;     // 攻撃中かどうか

        private void Start()
        {
            StartCoroutine(AttackRoutine());  // 攻撃のルーチンを開始
        }

        private void Update()
        {
            if (health <= 0f)
            {
                Die(); // ボスの死亡処理
            }
        }

        // ボスの死亡処理
        private void Die()
        {
            // 死亡アニメーションやエフェクトを追加可能
            Destroy(gameObject); // ボスを削除
        }

        // 攻撃パターンを定期的に変更するルーチン
        private IEnumerator AttackRoutine()
        {
            while (true)
            {
                if (!isAttacking)
                {Random
                    isAttacking = true;
                    // ランダムで攻撃パターンを切り替える
                    int pattern = .Range(0, 3);
                    switch (pattern)
                    {
                        case 0:
                            StartCoroutine(ShootStraight());  // 直線攻撃
                            break;
                        case 1:
                            StartCoroutine(ShootCircular()); // 円形攻撃
                            break;
                        case 2:
                            StartCoroutine(ShootSpread());   // 拡散攻撃
                            break;
                    }
                    yield return new WaitForSeconds(attackCooldown);
                    isAttacking = false;
                }
                yield return null;
            }
        }

        // 直線的に弾を発射する攻撃
        private IEnumerator ShootStraight()
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(0.2f); // 弾を間隔を開けて発射
            }
        }

        // 円形に弾を放つ攻撃
        private IEnumerator ShootCircular()
        {
            int bulletCount = 8;
            float angleStep = 360f / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * angleStep;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                Instantiate(bulletPrefab, firePoint.position, rotation);
                yield return new WaitForSeconds(0.1f); // 間隔を開けて発射
            }
        }

        // 弾を放射状に拡散する攻撃
        private IEnumerator ShootSpread()
        {
            int bulletCount = 5;
            float angleStep = 30f; // 弾の間隔を30度に設定
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - 2) * angleStep; // 中心から-60度~60度に発射
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                Instantiate(bulletPrefab, firePoint.position, rotation);
                yield return new WaitForSeconds(0.2f); // 間隔を開けて発射
            }
        }
    
}
