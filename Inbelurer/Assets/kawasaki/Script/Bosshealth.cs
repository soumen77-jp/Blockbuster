using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshealth : MonoBehaviour
{
    public float health = 50f;  // �G�̗̑�

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // �G������
    }

}
