using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Text damageText; //�_�[���[�W�e�L�X�g���i�[
    [SerializeField] private GameObject enemy; //�G�L�������i�[

    private Vector3 enemyPos;//�G�L�����̍��W���i�[
    private GameObject canvas;//�e�ɂ���L�����o�X���i�[


    // Start is called before the first frame update
    void Start()
    {
        //�G�L�����̍��W���擾
        enemyPos = enemy.GetComponent<Transform>().position;

        //�e�ɂ���L�����o�X���擾
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