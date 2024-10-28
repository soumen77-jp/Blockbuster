using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendClickMove : MonoBehaviour
{
    public float speed = 5f;  // �ړ����x
    private GameObject selectedObject = null;  // �I�����ꂽ�I�u�W�F�N�g
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // ���N���b�N�őI���܂��͈ړ�����w��
        if (Input.GetMouseButtonDown(0))
        {
            // �}�E�X�̃��[���h���W���擾
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // z����0�ɐݒ肵��2D��Ԃɂ���

            // ���C�L���X�g�ŃN���b�N�����I�u�W�F�N�g���擾
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // �����N���b�N�����ꏊ�ɉ����I�u�W�F�N�g���������ꍇ
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;

                // �I�u�W�F�N�g���ufriend�v�^�O�����ꍇ�ɂ̂ݑI��
                if (clickedObject.CompareTag("friend"))
                {
                    // �I�����ꂽ�I�u�W�F�N�g���Z�b�g
                    selectedObject = clickedObject;
                    Debug.Log("Selected object: " + selectedObject.name);
                }
            }
            else if (selectedObject != null)
            {
                // �����N���b�N���Ȃ������i�w�i�Ȃǁj�ꍇ�́A�I�𒆂̃I�u�W�F�N�g���ړ�
                targetPosition = mousePosition;
                isMoving = true;
                Debug.Log("Target position set: " + targetPosition);
            }
        }

        // �I�������I�u�W�F�N�g�����炩�Ɉړ�������
        if (isMoving && selectedObject != null)
        {
            // �I�����ꂽ�I�u�W�F�N�g��ڕW�ʒu�Ɍ������Ĉړ�������
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, targetPosition, speed * Time.deltaTime);

            // �ڕW�ʒu�ɓ��B�������m�F
            if (Vector3.Distance(selectedObject.transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // �ړ�����
                Debug.Log("Object reached target position.");
            }
        }
    }
}
