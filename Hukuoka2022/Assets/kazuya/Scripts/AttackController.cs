using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Text damageText; //ダーメージテキストを格納
    [SerializeField] private GameObject enemy; //敵キャラを格納

    private Vector3 enemyPos;//敵キャラの座標を格納
    private GameObject canvas;//親にするキャンバスを格納


    // Start is called before the first frame update
    void Start()
    {
        //敵キャラの座標を取得
        enemyPos = enemy.GetComponent<Transform>().position;

        //親にするキャンバスを取得
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Text text;
        text = Instantiate(damageText, new Vector3(0, 0, 0), Quaternion.identity);
        text.transform.SetParent(canvas.transform, false);
        text.transform.position = enemyPos;
    }
}