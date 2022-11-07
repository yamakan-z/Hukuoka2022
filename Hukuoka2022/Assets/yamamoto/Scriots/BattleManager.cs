//バトル画面の処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] card_generation = new GameObject[10];//生成するカードを入れる

    public GameObject PlayerCardArea;//プレイヤーのカード生成場所

    public GameObject EnemyCardArea;//相手のカード生成場所

    public Transform parent;

    [SerializeField]
    private int p_cardnum;//RayCast2Dから持ってきたカードの数字を代入する

    [SerializeField]
    private int e_cardnum;//RayCast2Dから持ってきたカードの数字を代入する(相手用）

    [SerializeField]
    private GameObject[] CloneCard;//生成したカードを入れる

    public Text Player_HPText;//プレイヤーのHPテキスト

    public Text Enemy_HPText;//敵のHPテキスト

    //----他のスクリプトから持ってくる-----
    public Player Player;//プレイヤースクリプトを持ってくる
    public Raycast2D Raycast2D;//スクリプトを持ってくる
    public JudgeManager JudgeManager;//judgeManagerスクリプトを持ってくる


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //テキストに現在のプレイヤーと敵のHPを表示
        Player_HPText.text = string.Format("{0}", Player.HP);//自身HP表示

        Enemy_HPText.text = string.Format("{0}", JudgeManager.enemy_HP);//敵HP表示


        //---------------バトル画面に選択したカードを表示する
        p_cardnum = Raycast2D.clicknum;//clicknumを代入

        e_cardnum=Raycast2D.e_select_num;

        CloneCard = GameObject.FindGameObjectsWithTag("CloneCard");//クローンしたカードのタグを探してゲームオブジェクトを取得

        //カード生成
        if (Raycast2D.card_g)
        {
            Instantiate(card_generation[p_cardnum], PlayerCardArea.transform.position, Quaternion.identity, parent);

            PlayerCardArea.transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする

            Instantiate(card_generation[e_cardnum], EnemyCardArea.transform.position, Quaternion.identity, parent);

            Raycast2D.card_g = false;
        }

        //カード削除
        if(Raycast2D.card_d)
        {
            //Destroy(CloneCard[]);

            foreach (GameObject obj in CloneCard)
            {
                Destroy(obj);//配列に入ったカード全削除
            }
        }
        //-----------------------------------------------
    }
}
