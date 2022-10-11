using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    GameObject clickcard;//クリックしたカードを入れるゲームオブジェクト


    public int clicknum;//選択したカードの数字を入れる変数

    public bool judge;//勝敗判定を始めるフラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //メインカメラ状のマウスカーソルのある位置からRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //レイヤーマスク作成
        //1<<〇でレイヤー番号を指定できる
        int layerMask = 1 << 6;//カードレイヤーマスク

        //Rayの長さ
        float maxDistance = 10;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        //カードのレイヤーチェック
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (Input.GetMouseButtonDown(0))
            {
                clickcard = null;//オブジェクトの初期化

                clickcard = hit.collider.gameObject;//クリックしたカードを取得する

                clicknum = clickcard.GetComponent<CardManager>().cardnum;//取得したカードの数字をclicknumに代入

                judge = true;//勝敗を決定する

                //Debug.Log(hit.collider.gameObject.name);

                Debug.Log(clicknum);
              
            }
        }


    }
}
