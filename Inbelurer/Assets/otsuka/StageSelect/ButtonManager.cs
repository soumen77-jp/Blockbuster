using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button buttonToShow1; // �\������ŏ��̃{�^��
    public Button buttonToShow2; // �\������2�ڂ̃{�^��
    public Button triggerButton; // �\�����g���K�[����{�^��
    private bool buttonsVisible = false; // �{�^���̕\����Ԃ�ǐՂ���t���O

    void Start()
    {
        buttonToShow1.gameObject.SetActive(false); // �ŏ��͔�\���ɂ���
        buttonToShow2.gameObject.SetActive(false); // �ŏ��͔�\���ɂ���
    }

    public void OnTriggerButtonClick()
    {
        buttonsVisible = !buttonsVisible; // �t���O�𔽓]������

        buttonToShow1.gameObject.SetActive(buttonsVisible); // �{�^���̕\����Ԃ�؂�ւ���
        buttonToShow2.gameObject.SetActive(buttonsVisible); // �{�^���̕\����Ԃ�؂�ւ���
    }
}

