//�o�g����ʂ̏���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] card_generation = new GameObject[10];//��������J�[�h������

    public GameObject PlayerCardArea;//�v���C���[�̃J�[�h�����ꏊ

    public GameObject EnemyCardArea;//����̃J�[�h�����ꏊ

    public Transform parent;

    [SerializeField]
    private int p_cardnum;//RayCast2D���玝���Ă����J�[�h�̐�����������

    [SerializeField]
    private int e_cardnum;//RayCast2D���玝���Ă����J�[�h�̐�����������(����p�j

    [SerializeField]
    private GameObject[] CloneCard;//���������J�[�h������

    public Text Player_HPText;//�v���C���[��HP�e�L�X�g

    public Text Enemy_HPText;//�G��HP�e�L�X�g

    //----���̃X�N���v�g���玝���Ă���-----
    public Player Player;//�v���C���[�X�N���v�g�������Ă���
    public Raycast2D Raycast2D;//�X�N���v�g�������Ă���
    public JudgeManager JudgeManager;//judgeManager�X�N���v�g�������Ă���


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�e�L�X�g�Ɍ��݂̃v���C���[�ƓG��HP��\��
        Player_HPText.text = string.Format("{0}", Player.HP);//���gHP�\��

        Enemy_HPText.text = string.Format("{0}", JudgeManager.enemy_HP);//�GHP�\��


        //---------------�o�g����ʂɑI�������J�[�h��\������
        p_cardnum = Raycast2D.clicknum;//clicknum����

        e_cardnum=Raycast2D.e_select_num;

        CloneCard = GameObject.FindGameObjectsWithTag("CloneCard");//�N���[�������J�[�h�̃^�O��T���ăQ�[���I�u�W�F�N�g���擾

        //�J�[�h����
        if (Raycast2D.card_g)
        {
            Instantiate(card_generation[p_cardnum], PlayerCardArea.transform.position, Quaternion.identity, parent);

            PlayerCardArea.transform.localScale = Vector3.one;//�J�[�h�̑傫����e�I�u�W�F�N�g�ɉe���󂯂Ȃ��悤�ɂ���

            Instantiate(card_generation[e_cardnum], EnemyCardArea.transform.position, Quaternion.identity, parent);

            Raycast2D.card_g = false;
        }

        //�J�[�h�폜
        if(Raycast2D.card_d)
        {
            //Destroy(CloneCard[]);

            foreach (GameObject obj in CloneCard)
            {
                Destroy(obj);//�z��ɓ������J�[�h�S�폜
            }
        }
        //-----------------------------------------------
    }
}
