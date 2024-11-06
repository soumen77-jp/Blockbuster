using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float offsetY = 2f; // カメラの少し下の位置を設定
    public float scrollLimit = 10f; // スクロールを止める位置

    void Update()
    {
        // プレイヤーが上に移動しているかを確認
        if (player.position.y > transform.position.y - offsetY && transform.position.y < scrollLimit)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        }
    }
}
