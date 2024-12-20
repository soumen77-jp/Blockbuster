using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // 弾が衝突した時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 壁に衝突したかを確認
        if (collision.CompareTag("Wall"))
        {
            // 弾と壁を消す
            Destroy(gameObject); // 自分自身(弾)を消す
          
        }
    }
}
