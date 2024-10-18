using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;           //移動スピード
    int direction = 0;                   //移動方向
    float axisH;                         //縦軸
    float axisV;                         //横軸
    Rigidbody2D rbody;                   //Rigidbody2D
    

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();    //Rigidbody2Dを得る
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");     //左右キー入力
        axisV = Input.GetAxisRaw("Vertical");       //上下キー入力
    }

    private void FixedUpdate()
    {
        //速度更新
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

}
