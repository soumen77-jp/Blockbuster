using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update

    //爆発範囲
    public float ExplosionRange = 0f;
    //爆発威力
    public float ExplosionDamage = 0f;
    //爆発のダメージ
    public int damage = 0;
    //爆発エフェクト
    public GameObject ExplosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        //爆発エフェクトの生成
        if(ExplosionEffect!=null)
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);

        }

        //爆発範囲内のコライダーを取得
        //foreach(Collider nearbyObject in colliders)


    }


}
