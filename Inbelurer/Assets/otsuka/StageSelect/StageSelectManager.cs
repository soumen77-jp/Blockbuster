using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public GameObject stage1Options; // Stage1�̃I�v�V�����{�^�����܂�GameObject
    public GameObject stage2Options; // Stage2�̃I�v�V�����{�^�����܂�GameObject
    public GameObject stage3Options; // Stage3�̃I�v�V�����{�^�����܂�GameObject
    public GameObject stage1Options2; // Stage1�̃I�v�V�����{�^��2���܂�GameObject
    public GameObject stage2Options2; // Stage2�̃I�v�V�����{�^��2���܂�GameObject
    public GameObject stage3Options2; // Stage3�̃I�v�V�����{�^��2���܂�GameObject

    void Start()
    {
        stage1Options.SetActive(false); // �ŏ��͔�\���ɂ���
        stage2Options.SetActive(false); // �ŏ��͔�\���ɂ���
        stage3Options.SetActive(false); // �ŏ��͔�\���ɂ���
        stage1Options2.SetActive(false); // �ŏ��͔�\���ɂ���
        stage2Options2.SetActive(false); // �ŏ��͔�\���ɂ���
        stage3Options2.SetActive(false); // �ŏ��͔�\���ɂ���
    }

    public void OnStage1ButtonClick()
    {
        stage1Options.SetActive(true); // Stage1�̃I�v�V������\��
        stage2Options.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options.SetActive(false); // Stage3�̃I�v�V�������\��
        stage1Options2.SetActive(true); // Stage1�̃I�v�V������\��
        stage2Options2.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options2.SetActive(false); // Stage3�̃I�v�V�������\��
    }

    public void OnStage2ButtonClick()
    {
        stage1Options.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options.SetActive(true); // Stage2�̃I�v�V������\��
        stage3Options.SetActive(false); // Stage3�̃I�v�V�������\��
        stage1Options2.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options2.SetActive(true); // Stage2�̃I�v�V������\��
        stage3Options2.SetActive(false); // Stage3�̃I�v�V�������\��
    }

    public void OnStage3ButtonClick()
    {
        stage1Options.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options.SetActive(true); // Stage3�̃I�v�V������\��
        stage1Options2.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options2.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options2.SetActive(true); // Stage3�̃I�v�V������\��
    }
}


