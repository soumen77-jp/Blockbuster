using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // �e�̑��x
    public float lifeTime = 2f;   // �e�̎���

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);  // ��莞�Ԍ�ɒe���폜
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // `Enemy`�^�O�����I�u�W�F�N�g�ɓ��������ꍇ
        if (other.CompareTag("Enemy"))
        {
            // �e�����ł�����
            Destroy(gameObject);
        }
    }
}
