using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{

    //配列を使用している時は[0]:1P [1]:2P
    [SerializeField]
    GameObject[] clickcard = new GameObject[2];//クリックしたカードを入れるゲームオブジェクト

    public GameObject Player1Canvans;//プレイヤー1キャンバス

    public GameObject Player2Canvas;//プレイヤー2キャンバス

    public GameObject BattleCanvas;//バトル画面を持ってくる

    public int Turn_flow = 1;//現在のプレイヤー　1：1P　2：2P 3:バトル画面

    public int[] clicknum;//選択したカードの数字を入れる変数

    public bool judge;//勝敗判定を始めるフラグ

    // Start is called before the first frame update
    void Start()
    {
        clicknum = new int[2];//配列の作成
        Player2Canvas.SetActive(false);//プレイヤー1からスタート
    }

    // Update is called once per frame
    void Update()
    {
        if (Turn_flow == 1)//1Pカード選択画面
        {
            BattleCanvas.SetActive(false);
            Player2Canvas.SetActive(false);
            Player1Canvans.SetActive(true);
        }
        else if (Turn_flow == 2)//2Pカード選択画面
        {
            Player1Canvans.SetActive(false);
            Player2Canvas.SetActive(true);
        }
        else if(Turn_flow == 3)//バトル画面
        {
            Player2Canvas.SetActive(false);
            BattleCanvas.SetActive(true);

            //仮の処理として左クリックで画面を切り替える
            if (Input.GetMouseButtonDown(0))
            {
                Turn_flow = 1;//ターンフローリセット
                Debug.Log("a");
            }
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
                if(Turn_flow == 1)
                {
                    clickcard[0] = hit.collider.gameObject;//クリックしたカードを取得する
                
                    clicknum[0] = clickcard[0].GetComponent<CardManager>().cardnum;//取得したカードの数字をclicknumに代入
                   
                    Turn_flow++;//2Pへターンを回す
                }
                //2P
                else if (Turn_flow == 2)
                {
                    clickcard[1] = hit.collider.gameObject;//クリックしたカードを取得する

                    clicknum[1] = clickcard[1].GetComponent<CardManager>().cardnum;//取得したカードの数字をclicknumに代入

                    Turn_flow++;//2Pへターンを回す

                    judge = true;//勝敗を決定する

                }
            }
        }



    }
}
