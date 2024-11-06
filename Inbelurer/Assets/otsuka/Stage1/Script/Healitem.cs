using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healitem : MonoBehaviour
{
    public GameObject ammoPrefab;
    public float spawnInterval = 10f;
    private bool isSpawning = false;

    void Start()
    {
        // ���������ɂ̓A�C�e���������J�n���Ȃ�
    }

    public void StartSpawningAmmo()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("TrySpawnAmmo", 0f, spawnInterval);
        }
    }

    void TrySpawnAmmo()
    {
        Instantiate(ammoPrefab, GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        // �J�����̏�̈ʒu�Ƀ����_���ɐ���
        float x = Random.Range(-3,3 );
        float y = Camera.main.orthographicSize + Camera.main.transform.position.y; // �J�����̏�[
        return new Vector3(x, y, 0);
    }

    public void OnAmmoCollected()
    {
        // �v���C���[���񕜃A�C�e����������琶���𒆒f
        CancelInvoke("TrySpawnAmmo");
        isSpawning = false;

        // ��ʊO�̉񕜃A�C�e�������ł�����
        battery[] ammoItems = FindObjectsOfType<battery>();
        foreach (battery item in ammoItems)
        {
            if (!item.GetComponent<Renderer>().isVisible)
            {
                Destroy(item.gameObject);
            }
        }
    }
}


