using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCost : MonoBehaviour
{

    public int cardcost;//�J�[�h�R�X�g

    public int enemy_cardcost;//�G�J�[�h�R�X�g

    [SerializeField]
    private Text cost_text;//�R�X�g�\���e�L�X�g

    [SerializeField]
    private Text enemycost_text;//�G�R�X�g�\���e�L�X�g

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
