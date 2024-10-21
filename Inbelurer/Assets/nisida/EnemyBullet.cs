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

    //Enemyを下移動させる
    private void Move()
    {
        transform.position +=
            new Vector3(0, -bulletSpeed, 0) * Time.deltaTime;
    }

    //Bulletが画面外に出たら消滅させる
    private void OffScreen()
    {

        if (this.transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
