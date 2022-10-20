using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    [SerializeField]
    private int protonum;//敵の数字（テスト用）

    [SerializeField]
    private int protoenemy;//敵の体力

    [SerializeField]
    private GameObject RayManager;//レイマネージャーを持ってくる（Raycast2Dで取得したclicknumを持ってくる）

    [SerializeField]
    private GameObject Player;//プレイヤースクリプトを持ってくる

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //勝敗判定
        if(RayManager.GetComponent<Raycast2D>().judge)
        {
            //勝ち
            if (RayManager.GetComponent<Raycast2D>().clicknum[0] > RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Debug.Log("P1勝利");
                P1Win();
            }
            //負け
            else if (RayManager.GetComponent<Raycast2D>().clicknum[0] < RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Debug.Log("P2勝利");
                P2Win();
            }
            //引き分け
            else if (protonum == RayManager.GetComponent<Raycast2D>().clicknum[1])
            {
                Dlow();
            }
        }
    }
    
    public void P1Win()
    {
        //勝利
        Debug.Log("勝ち");
        protoenemy -= RayManager.GetComponent<Raycast2D>().clicknum[0] - RayManager.GetComponent<Raycast2D>().clicknum[1];
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void P2Win()
    {
        //負け
        Debug.Log("負け");
        Player.GetComponent<Player>().HP-= RayManager.GetComponent<Raycast2D>().clicknum[1] - RayManager.GetComponent<Raycast2D>().clicknum[0];
        RayManager.GetComponent<Raycast2D>().judge = false;
    }

    public void Dlow()
    {
        //引き分け
        Debug.Log("引き分け");
        RayManager.GetComponent<Raycast2D>().judge = false;
    }
}
