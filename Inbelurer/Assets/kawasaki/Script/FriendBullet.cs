using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet : MonoBehaviour
{

    public GameObject FriendBulletPrefab;
    private int cnt;
    public int BulletSpeed; //�e��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cnt += 1;

        if (cnt % BulletSpeed == 0) //�e�̔��ˑ��x
        {
            GameObject FriendBullet = Instantiate(FriendBulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D FriendBulletRb = FriendBullet.GetComponent<Rigidbody2D>();
            FriendBulletRb.AddForce(transform.forward * 500);
            Destroy(FriendBullet, 1.0f);//�e�̏���
        }
    }
}
