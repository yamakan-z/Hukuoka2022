using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCreata : MonoBehaviour
{
    [SerializeField]
    GameObject[] PlayerCard_Create;//プレイヤー手札カード生成

    [SerializeField]
    GameObject[] EnemyCard_Create;//プレイヤー手札カード生成

    [SerializeField]
    GameObject[] P_HandCreateArea;//カード生成場所

    [SerializeField]
    private int rand_num;//ランダムに生成した数字

    [SerializeField]
    List<int> rand = new List<int>();//山札

    [SerializeField]
    private int[] deck;//同じ配列のカードの重複を避けた山札

    int count;

    [SerializeField]
    private int max;//残りの山札カード枚数

    public Transform parent;

  
    /// <summary>
    /// ランダムな数字を生成する
    /// </summary>
    public void RandNumCreate()
    {
        rand_num = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {

        deck = new int[20];

        for(int i=0;i<20;i++)
        {
            rand.Add(i);
        }

        //同じ配列のカードをとらないようにする
        while(rand.Count>0)
        {

            rand_num = Random.Range(0,rand.Count);

            int r = rand[rand_num];
            Debug.Log(r);

            deck[count] =r;
            count++;

            rand.RemoveAt(rand_num);

            
        }

        
        for(int i=0;i<5;i++)
        {
            Instantiate(PlayerCard_Create[deck[i]], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

            P_HandCreateArea[i].transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする

            max++;
        }


    }

    //最初の5枚以降のカード生成を行う
    public void CardCreate()
    {
        Instantiate(PlayerCard_Create[deck[max]], P_HandCreateArea[max].transform.position, Quaternion.identity, parent);

        P_HandCreateArea[max].transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする

        max++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
