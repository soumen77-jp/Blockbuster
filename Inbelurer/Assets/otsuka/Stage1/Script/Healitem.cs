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
        // 初期化時にはアイテム生成を開始しない
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
        // プレイヤーが回復アイテムを取ったら生成を中断
        CancelInvoke("TrySpawnAmmo");
        isSpawning = false;
    }
}

