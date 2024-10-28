using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public AudioClip shotSE;
    public GameObject BulletPrefab;
    public GameObject FirePoint;
    public GameObject explosion;


    public static float px = 0;//���@�ʒu���O���t�@�C���Q�Ɨp
    public static float py = 0;//���@�ʒu���O���t�@�C���Q�Ɨp



    AudioSource audioSource;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();

        //������������������������������������������������������������
        //���@�̈ʒu��0.7���~���ƂŃ��O�𔭐������Ă���
        px = transform.position.x * 0.7f;//���@�_���e�p
        py = transform.position.y * 0.7f;//���@�_���e�p
        //���������������������������������������������������������܂Œǉ�
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 nextPoint = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4;

        nextPoint = new Vector3(
            Mathf.Clamp(nextPoint.x, -2.9f, 2.9f),
            Mathf.Clamp(nextPoint.y, -2f, 2f),
            0
            );

        transform.position = nextPoint;
    }
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(shotSE);
            Instantiate(BulletPrefab, FirePoint.transform.position, transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameController.GameOver();
        }
    }
}