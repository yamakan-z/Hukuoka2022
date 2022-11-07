using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCost : MonoBehaviour
{

    public int cardcost;//カードコスト

    public int enemy_cardcost;//敵カードコスト

    [SerializeField]
    private Text cost_text;//コスト表示テキスト

    [SerializeField]
    private Text enemycost_text;//敵コスト表示テキスト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cost_text.text = ""+ cardcost;

        enemycost_text.text = "" + enemy_cardcost;

    }
}
