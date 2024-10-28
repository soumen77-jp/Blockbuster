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
        Instantiate(ammoPrefab, GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    public void OnAmmoCollected()
    {
        // プレイヤーが回復アイテムを取ったら生成を中断
        CancelInvoke("TrySpawnAmmo");
        isSpawning = false;

        // 画面外の回復アイテムを消滅させる
        Battery[] ammoItems = FindObjectsOfType<Battery>();
        foreach (Battery item in ammoItems)
        {
            if (!item.GetComponent<Renderer>().isVisible)
            {
                Destroy(item.gameObject);
            }
        }
    }
}


