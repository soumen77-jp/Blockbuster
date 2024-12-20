using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendBULLET : MonoBehaviour
{
    public float damage = 10f;  // 弾の攻撃力

    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たったときの処理
        Bosshealth enemy = other.gameObject.GetComponent<Bosshealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
    }

}
