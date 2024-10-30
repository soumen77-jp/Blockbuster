using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update

    //�����͈�
    public float ExplosionRange = 0f;
    //�����З�
    public float ExplosionDamage = 0f;
    //�����̃_���[�W
    public int damage = 0;
    //�����G�t�F�N�g
    public GameObject ExplosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        //�����G�t�F�N�g�̐���
        if(ExplosionEffect!=null)
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);

        }

        //�����͈͓��̃R���C�_�[���擾
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRange);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)
            {
                rb.AddExplosionForce(ExplosionDamage, transform.position, ExplosionRange);
            }



        }

        Destroy(gameObject);

    }


}
