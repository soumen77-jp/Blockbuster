using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    int currentBullets = 0; //�e�̏�����
    public GameObject BulletText;
    int hp = 0; //�v���C���[��HP
    public GameObject lifeImage; //HP�̐���\������Image
    public Sprite life3Image; //HP3�摜
    public Sprite life2Image; //HP2�摜
    public Sprite life1Image; //HP1�摜
    public Sprite life0Image; //HP0�摜
    // Start is called before the first frame update
    
    //�A�C�e�����X�V
    void UpdateItemCount()
    {
        //�e
        if(currentBullets != ItemKeeper.currentBullets)
        {
            BulletText.GetComponent<Text>().text = ItemKeeper.currentBullets.ToString();
            currentBullets = ItemKeeper.currentBullets;
        }
    }
    void UpdateHP()
    {
       //Player�擾
       if(PlayerController.gameState != "gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                if(PlayerController.hp != hp)
                {
                    hp = PlayerController.hp;
                    if(hp <= 0)
                    {
                        lifeImage.GetComponent<Image>().sprite = life0Image;
                        //�v���C���[���S
                        PlayerController.gameState = "gameend"; //�Q�[���I��
                    }
                    else if(hp == 1)
                    {
                        lifeImage.GetComponent<Image>().sprite = life1Image;
                    }
                    else if (hp == 2)
                    {
                        lifeImage.GetComponent<Image>().sprite = life2Image;
                    }
                    else
                    {
                        lifeImage.GetComponent<Image>().sprite = life3Image;
                    }
                }
            }
       }
    }
    void Start()
    {
        UpdateHP(); //HP�X�V
        UpdateItemCount(); //�A�C�e�����X�V
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemCount(); //�A�C�e�����X�V
        UpdateHP(); //HP�X�V
    }
}
