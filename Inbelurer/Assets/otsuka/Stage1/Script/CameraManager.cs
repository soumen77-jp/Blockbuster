using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float offsetY = 2f; // �J�����̏������̈ʒu��ݒ�
    public float scrollLimit = 10f; // �X�N���[�����~�߂�ʒu

    void Update()
    {
        // �v���C���[����Ɉړ����Ă��邩���m�F
        if (player.position.y > transform.position.y - offsetY && transform.position.y < scrollLimit)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        }
    }
}
