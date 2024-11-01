using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckBullet : MonoBehaviour
{
    public float damage = 10f;  // �e�̍U����

    void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ɓ��������Ƃ��̏���
        Bosshealth enemy = other.gameObject.GetComponent<Bosshealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }
    }

}
