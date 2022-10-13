using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    //配列を使用している時は[0]:1P [1]:2P
    [SerializeField]
    GameObject[] clickcard = new GameObject[2];//クリックしたカードを入れるゲームオブジェクト

    public GameObject Player1Canvans;//プレイヤー1キャンバス

    public GameObject Player2Canvans;//プレイヤー2キャンバス

    public int Player_turn = 1;//現在のプレイヤー　1：1P　2：2P

    public bool j_start = false;//勝敗フラグを呼び出す

    public int[] clicknum;//選択したカードの数字を入れる変数

    public bool judge;//勝敗判定を始めるフラグ

    // Start is called before the first frame update
    void Start()
    {
        clicknum = new int[2];//配列の作成
        Player2Canvans.SetActive(false);//プレイヤー1からスタート
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_turn == 1)
        {
            Player2Canvans.SetActive(false);
            Player1Canvans.SetActive(true);
        }
        else if (Player_turn == 2)
        {
            Player1Canvans.SetActive(false);
            Player2Canvans.SetActive(true);
        }




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
                //clickcard = null;//オブジェクトの初期化

                //プレイヤーターンによって1P・2Pの選択したカードを取得する
                //1P
                if(Player_turn==1)
                {
                    clickcard[0] = hit.collider.gameObject;//クリックしたカードを取得する
                    Debug.Log("a");

                    clicknum[0] = clickcard[0].GetComponent<CardManager>().cardnum;//取得したカードの数字をclicknumに代入
                    Debug.Log("b");

                    Player_turn++;//2Pへターンを回す
                }
                //2P
                else if (Player_turn == 2)
                {
                    clickcard[1] = hit.collider.gameObject;//クリックしたカードを取得する

                    clicknum[1] = clickcard[1].GetComponent<CardManager>().cardnum;//取得したカードの数字をclicknumに代入

                    j_start = true;
                }

                if(j_start)
                {
                    judge = true;//勝敗を決定する
                }
                   
               // Debug.Log(clicknum);
              
            }
        }



    }
}
