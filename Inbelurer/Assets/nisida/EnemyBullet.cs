using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(1);
        //�v���C���[�Ƀ_���[�W��^���鏈���������ɒǉ�
        Destroy(other.gameObject);

    }
    

}