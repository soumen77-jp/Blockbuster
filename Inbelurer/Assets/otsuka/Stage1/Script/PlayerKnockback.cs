using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 10f; // �m�b�N�o�b�N�̋���
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            // �_���[�W�����������ɒǉ�
        }
    }
}

