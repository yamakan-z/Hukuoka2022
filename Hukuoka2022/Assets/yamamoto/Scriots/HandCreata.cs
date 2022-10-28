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
    private int rand;

    public Transform parent;


    /// <summary>
    /// ランダムな数字を生成する
    /// </summary>
    public void RandNumCreate()
    {
        rand = Random.Range(0, 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<5;i++)
        {
            RandNumCreate();//ランダム数字生成

            Debug.Log(rand);

            Instantiate(PlayerCard_Create[rand], P_HandCreateArea[i].transform.position, Quaternion.identity, parent);

            P_HandCreateArea[i].transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
