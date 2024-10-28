using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healitem : MonoBehaviour
{
    public GameObject ammoPrefab;
    public int maxAmmoItems = 3;
    private int currentAmmoItems = 0;
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
        if (currentAmmoItems < maxAmmoItems)
        {
            Instantiate(ammoPrefab, GetRandomPosition(), Quaternion.identity);
            currentAmmoItems++;
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    public void OnAmmoCollected()
    {
        currentAmmoItems--;
        // �v���C���[���񕜃A�C�e����������琶���𒆒f
        CancelInvoke("TrySpawnAmmo");
        isSpawning = false;
    }
}

