using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] card_generation = new GameObject[10];//生成するカードを入れる

    public GameObject PlayerCardArea;//プレイヤーのカード生成場所

    public GameObject EnemyCardArea;//相手のカード生成場所

    public Transform parent;


    void Start()
    {
        Instantiate(card_generation[1], PlayerCardArea.transform.position, Quaternion.identity, parent);

        PlayerCardArea.transform.localScale = Vector3.one;//カードの大きさを親オブジェクトに影響受けないようにする


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
