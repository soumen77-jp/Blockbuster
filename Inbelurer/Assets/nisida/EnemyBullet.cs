using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private int bulletSpeed = 8;

    // Update is called once per frame
    void Update()
    {
        Move();
        OffScreen();
    }

    //Enemy�����ړ�������
    private void Move()
    {
        transform.position +=
            new Vector3(0, -bulletSpeed, 0) * Time.deltaTime;
    }

    //Bullet����ʊO�ɏo������ł�����
    private void OffScreen()
    {

        if (this.transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
