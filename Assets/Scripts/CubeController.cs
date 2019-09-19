using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    AudioClip clip;

    // Use this for initialization
    void Start()
    {
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter2D(Collision2D other)
    {
        // 課題：地面とCube又はCube同士の衝突時には音を発生させる。Tagを設定してTagで判定している
        if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
