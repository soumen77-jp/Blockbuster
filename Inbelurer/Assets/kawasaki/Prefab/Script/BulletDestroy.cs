using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // �e���Փ˂������̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ǂɏՓ˂��������m�F
        if (collision.CompareTag("Wall"))
        {
            // �e�ƕǂ�����
            Destroy(gameObject); // �������g(�e)������
          
        }
    }
}
