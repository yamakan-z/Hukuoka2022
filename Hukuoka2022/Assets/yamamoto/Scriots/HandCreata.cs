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
    List<int> rand = new List<int>();

    public Transform parent;

    [SerializeField]
    List<GameObject> P_CardList = new List<GameObject>();//プレイヤーの手札を被りなく

    /// <summary>
    /// ランダムな数字を生成する
    /// </summary>
    public void RandNumCreate()
    {
        rand[0] = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {
       
        for(int i=0;i<5;i++)
        {
            //  RandNumCreate();//ランダム数字生成

            rand.Add(i);

            Debug.Log(rand);

            //P_CardList.Add(PlayerCard_Create[rand]);

            //Instantiate(PlayerCard_Create[rand], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

           // P_HandCreateArea[i].transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
