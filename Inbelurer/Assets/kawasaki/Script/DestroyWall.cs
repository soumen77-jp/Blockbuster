using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // ���������I�u�W�F�N�g�S�Ă�����
        Destroy(other.gameObject);
    }

}
